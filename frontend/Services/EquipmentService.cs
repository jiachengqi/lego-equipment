using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;
using shared;

namespace frontend.Services
{
    public class EquipmentService : IEquipmentService, IAsyncDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly HubConnection _hubConnection;
        private readonly ILogger<EquipmentService> _logger;
        private bool _disposed;

        public event Action<Equipment> OnEquipmentStateUpdated;
        public event Action OnReconnecting;
        public event Action OnReconnected;
        public event Action OnClosed;

        public EquipmentService(HttpClient httpClient, ILogger<EquipmentService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _hubConnection = BuildHubConnection();
        }

        private HubConnection BuildHubConnection()
        {
            var hubUrl = new Uri(_httpClient.BaseAddress, "equipmentHub");

            return new HubConnectionBuilder().WithUrl(hubUrl).WithAutomaticReconnect().Build();
        }

        private void SetupHubEventHandlers()
        {
            _hubConnection.On<Equipment>("ReceiveEquipmentStateUpdate", equipment =>
            {
                _logger.LogInformation("received state update for Equipment {EquipmentId}", equipment.Id);
                OnEquipmentStateUpdated?.Invoke(equipment);
            });

            _hubConnection.Reconnecting += error =>
            {
                _logger.LogInformation(error, "SignalR connection is reconnecting");
                OnReconnecting?.Invoke();
                return Task.CompletedTask;
            };

            _hubConnection.Reconnected += connectionId =>
            {
                _logger.LogInformation("SignalR reconnected, connection id {ConnectionId}", connectionId);
                OnReconnected?.Invoke();
                return Task.CompletedTask;
            };

            _hubConnection.Closed += error =>
            {
                _logger.LogInformation(error, "SignalR connection closed");
                OnClosed?.Invoke();
                return Task.CompletedTask;
            };
        }

        public async Task InitializeAsync()
        {
            SetupHubEventHandlers();
            try
            {
                await _hubConnection.StartAsync();
                _logger.LogInformation("Connected to SignalR hub");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while connecting to SignalR hub");
            }
        }

        public async Task<List<Equipment>> GetEquipmentAsync()
        {
            try
            {
                var equipmentList = await _httpClient.GetFromJsonAsync<List<Equipment>>("api/equipment");
                return equipmentList;
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "HTTP error while fetching equipment list");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while fetching equipment list");
                throw;
            }
        }

        public async Task UpdateEquipmentStateAsync(int id, EquipmentState newState)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/equipment/{id}/state", newState);
                response.EnsureSuccessStatusCode();
                _logger.LogInformation("updated state for Equipment ID: {EquipmentId}", id);
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "http error while updating state for equipment {EquipmentId}", id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while updating state for equipment {EquipmentId}", id);
                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
                return;

            try
            {
                if (_hubConnection != null)
                {
                    await _hubConnection.StopAsync();
                    await _hubConnection.DisposeAsync();
                    _logger.LogInformation("SignalR connection stopped and disposed");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while disposing SignalR connection");
            }
            finally
            {
                _disposed = true;
            }
        }
    }
}
