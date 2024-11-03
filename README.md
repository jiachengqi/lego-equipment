# Lego Equipment Management

## Overview

**Lego Equipment Management** is a simple project built with **C#**, leveraging **Entity Framework**, **SignalR**, **Blazor WebAssembly**, and **SQLite**. This application allows users to manage and monitor equipment states in real-time through a responsive web interface.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
  - [Clone the Repository](#clone-the-repository)
  - [Running the Project](#running-the-project)
    - [Option A: Using Visual Studio](#option-a-using-visual-studio)
    - [Option B: Using Terminal](#option-b-using-terminal)
- [Configuration](#configuration)
- [Troubleshooting](#troubleshooting)
  
## Prerequisites

Before running the project, ensure you have the following installed on your system:

- [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (optional, for Visual Studio users)

## Getting Started

### Clone the Repository

1. **Open Terminal or Powershell:**

2. **Clone the Repository:**

   ```bash
   git clone https://github.com/jiachengqi/lego-equipment.git
   cd lego-equipment
   ```

### Running the Project

> **Important:** Ensure that ports 5001 and 5151 are not occupied on your machine, as the backend and frontend projects will run on these ports respectively.

#### Option A: Using Visual Studio

1. **Open the Solution:**

   - Launch Visual Studio.
   - Open the `lego-equipment.sln` file located in the cloned repository.

2. **Run Projects Separately:**

   - **Run Backend:**
     - In the Solution Explorer, locate the Backend project.
     - Right-click on the Backend project and select **Run** or **Start Debugging**.

   - **Run Frontend:**
     - In the Solution Explorer, locate the Frontend project.
     - Right-click on the Frontend project and select **Run** or **Start Debugging**.

3. **Access the Application:**

   - Once both projects are running, open your web browser and navigate to [https://localhost:5151](https://localhost:5151) to use the application.

#### Option B: Using Terminal

1. **Build the Project:**

   ```bash
   cd lego-equipment
   dotnet build
   ```

2. **Run the Backend:**

   ```bash
   cd backend
   dotnet run
   ```

   The backend will start and listen on port 5001.

3. **Run the Frontend:**

   - Open a new terminal window or tab.
   - Navigate to the frontend directory and run the frontend project.

   ```bash
   cd frontend
   dotnet run
   ```

   The frontend will start and listen on port 5151.

4. **Access the Application:**

   - Open your web browser and navigate to [https://localhost:5151](https://localhost:5151) to use the application.

## Configuration

- **Ports:** The backend and frontend are configured to run on ports 5001 and 5151 respectively. If these ports are already in use, you can modify the `launchSettings.json` files in each project to use different ports.

  - **Backend Configuration (`backend/Properties/launchSettings.json`):**

    ```json
    {
      "profiles": {
        "https": {
          "commandName": "Project",
          "launchBrowser": true,
          "launchUrl": "swagger",
          "applicationUrl": "https://localhost:5001",
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
          },
          "dotnetRunMessages": true
        }
      }
    }
    ```

    Modify `applicationUrl` if needed.

  - **Frontend Configuration (`frontend/Properties/launchSettings.json`):**

    ```json
    {
      "profiles": {
        "http": {
          "commandName": "Project",
          "launchBrowser": true,
          "inspectUri": "{wsProtocol}://{url.hostname}:{url.port}/_framework/debug/ws-proxy?browser={browserInspectUri}",
          "applicationUrl": "http://localhost:5151",
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
          },
          "dotnetRunMessages": true
        }
      }
    }
    ```

    Modify `applicationUrl` if needed.

- **Database:** The project uses SQLite for data storage. Ensure that Entity Framework migrations are applied before running the application if you want to change the pre-injected example data.

  - **Apply Migrations:**

    ```bash
    cd backend
    dotnet ef database update
    ```

## Troubleshooting

- **Port Occupied Error:**
  - If you encounter errors indicating that ports 5001 or 5151 are in use, either free those ports or update the `launchSettings.json` files in the Backend and Frontend projects to use different ports.

- **Dependency Issues:**
  - Ensure all NuGet packages are restored. Run `dotnet restore` in both Backend and Frontend directories if necessary.

- **SignalR Connection Problems:**
  - Verify that the SignalR hub is correctly configured and that the client is connecting to the right URL.

- **Entity Framework Migration Issues:**
  - Ensure that the `dotnet-ef` tool is installed globally:

    ```bash
    dotnet tool install --global dotnet-ef
    ```

  - Apply migrations:

    ```bash
    cd backend
    dotnet ef database update
    ```
