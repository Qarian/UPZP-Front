using System;
using mainServer.schemas.FWaitingRoom;
using UnityEngine;

public class WaitingRoomInfo
{
    public enum Vehicle
    {
        Pedestrian,
        Cyclist,
        Car
    }

    private Vehicle GetVehicle(FVehicleType vehicleType)
    {
        switch (vehicleType)
        {
            case FVehicleType.Pedestrian:
                return Vehicle.Pedestrian;
            case FVehicleType.Cyclist:
                return Vehicle.Cyclist;
            case FVehicleType.Car:
                return Vehicle.Car;
            default:
                throw new ArgumentOutOfRangeException(nameof(vehicleType), vehicleType, null);
        }
    }
    
    public struct Player
    {
        public string name;
        public int id;
        public Vehicle Vehicle;
    }

    public string city;
    public int host;
    public int maxClients;
    public Player[][] teams;

    public WaitingRoomInfo(FWaitingRoom data)
    {
        city = data.City;
        host = data.Host;
        maxClients = data.ClientsMax;

        if (data.TeamsLength != 2)
        {
            Debug.LogError($"There are {data.TeamsLength} teams!");
            throw new Exception($"There are {data.TeamsLength} teams!");
        }

        teams = new Player[2][];
        for (int i = 0; i < 2; i++)
        {
            int size = data.Teams(i).Value.ClientsLength;
            teams[i] = new Player[size];
            for (int j = 0; j < size; j++)
            {
                FClient player = data.Teams(i).Value.Clients(j).Value;
                teams[i][j].id = player.Id;
                teams[i][j].name = player.Name;
                teams[i][j].Vehicle = GetVehicle(player.Vehicle.Value.VehicleType);
            }
        }
    }
}
