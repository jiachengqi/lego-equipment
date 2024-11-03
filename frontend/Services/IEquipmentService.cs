using shared;

namespace frontend.Services
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetEquipmentAsync();
        Task UpdateEquipmentStateAsync(int id, EquipmentState newState);
        Task InitializeAsync();
        event Action<Equipment> OnEquipmentStateUpdated;
        event Action OnReconnecting;
        event Action OnReconnected;
        event Action OnClosed;
    }
}

