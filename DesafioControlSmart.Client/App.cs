﻿using DesafioControlSmart.Data;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yansoft.Rest;

using static DesafioControlSmart.Data.DataConstants;

namespace DesafioControlSmart.Client
{
    public class App
    {
        private const string ServerUrlKey = "ServerUrl";

        private HubConnection _connection;
        private RestHttpClient _client;

        private App() { }

        public static App Instance { get; private set; } = new App();

        public async Task StartAsync()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>(ServerUrlKey, "http://localhost:51630") })
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables("DCS_")
                .Build();

            var baseUrl = config[ServerUrlKey];

            _client = new RestHttpClient
            {
                BaseAddress = new Uri($"{baseUrl}/api/")
            };

            _connection = new HubConnectionBuilder()
                .WithUrl($"{baseUrl}/{HubPath}")
                .Build();

            _connection.Closed += async (e) =>
            {
                await Task.Delay(3000);
                await _connection.StartAsync();
            };

            _connection.On<Camera>(ClientCameraStatusMethod, ChangeCameraStatusAsync);
            _connection.On<Gate>(ClientCameraStatusMethod, ChangeGateStatusAsync);

            await _connection.StartAsync();
        }

        public async Task StopAsync()
        {
            if (_connection != null)
            {
                await _connection.StopAsync();
                await _connection.DisposeAsync();
                _connection = null; 
            }

            _client?.Dispose();
            _client = null;


        }

        private async void ChangeCameraStatusAsync(Camera camera)
        {
            var log = new DeviceEvent
            {
                Device = camera,
                Success = true,
            };

            switch (camera.Status)
            {
                case DeviceStatus.Off:
                    await camera.Desliga();
                    log.Description = $"Câmera {camera.IP} desligada";
                    break;
                case DeviceStatus.On:
                    await camera.Liga();
                    log.Description = $"Câmera {camera.IP} ligada";
                    break;
                default:
                    log.Description = "Tentativa de configurar câmera com status inválido";
                    log.Success = false;
                    break;
            }

            await _client.PostAsync<DeviceEvent>(ApiLogPath, log);
        }

        private async void ChangeGateStatusAsync(Gate gate)
        {
            var log = new DeviceEvent
            {
                Device = gate,
                Success = true
            };

            switch (gate.Status)
            {
                case DeviceStatus.Off:
                    await gate.Desliga();
                    log.Description = $"Portão {gate.IP} desligado";
                    break;
                case DeviceStatus.On:
                    await gate.Liga();
                    log.Description = $"Portão {gate.IP} ligado";
                    break;
                default:
                    log.Description = "Tentativa de configurar portão com status inválido";
                    log.Success = false;
                    break;
            }

            await _client.PostAsync<DeviceEvent>(ApiLogPath, log);
        }
    }
}
