using System.Collections;
using System.Collections.Generic;
using FlatBuffers;
using mainServer.schemas.FChooseWaitingRoom;
using mainServer.schemas.FMessage;
using mainServer.schemas.FNewWaitingRoom;
using mainServer.schemas.FWaitingRoom;
using Networking;
using TestData;
using UnityEngine;
using Upzp.GameStatus;

public static class Serializer
{
    public static byte[] NewGameCreated(string city, string name, int maxClients)
    {
        var builder = new FlatBufferBuilder(50);
            
        var cityOffset = builder.CreateString(city);
        var nameOffset = builder.CreateString(name);

        FNewWaitingRoom.StartFNewWaitingRoom(builder);
        FNewWaitingRoom.AddCity(builder, cityOffset);
        FNewWaitingRoom.AddName(builder, nameOffset);
        FNewWaitingRoom.AddClientsMax(builder, maxClients);
        var roomObj = FNewWaitingRoom.EndFNewWaitingRoom(builder);
        builder.Finish(roomObj.Value);

        return builder.SizedByteArray();
    }

    public static byte[] ChooseRoom(int roomId)
    {
        var builder = new FlatBufferBuilder(4);
        
        FChooseWaitingRoom.StartFChooseWaitingRoom(builder);
        FChooseWaitingRoom.AddId(builder, roomId);
        var roomObj = FChooseWaitingRoom.EndFChooseWaitingRoom(builder);
        builder.Finish(roomObj.Value);
        
        return builder.SizedByteArray();
    }

    public static byte[] NewVehicle(int vehicleId)
    {
        var builder = new FlatBufferBuilder(4);
        
        FVehicle.StartFVehicle(builder);
        switch (vehicleId)
        {
            case 0:
                FVehicle.AddVehicleType(builder, FVehicleType.Pedestrian);
                break;
            case 1:
                FVehicle.AddVehicleType(builder, FVehicleType.Cyclist);
                break;
            case 2:
            default:
                FVehicle.AddVehicleType(builder, FVehicleType.Car);
                break;
        }
        FVehicle.AddVelocity(builder, 1);
        var vehicleObj = FVehicle.EndFVehicle(builder);
        builder.Finish(vehicleObj.Value);

        return builder.SizedByteArray();
    }

    public static byte[] SimpleMessage(int messageId)
    {
        var builder = new FlatBufferBuilder(4);
        
        FMessage.StartFMessage(builder);
        switch (messageId)
        {
            case 0:
                FMessage.AddMessageType(builder, FMessageType.StartGame);
                break;
            case 1:
            default:
                FMessage.AddMessageType(builder, FMessageType.LeaveRoom);
                break;
        }
        var messageObj = FMessage.EndFMessage(builder);
        builder.Finish(messageObj.Value);

        return builder.SizedByteArray();
    }
}
