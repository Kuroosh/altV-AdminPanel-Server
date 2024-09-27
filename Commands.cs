using System.Net;
using System.Numerics;
using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;

namespace AdminPanel;

public class Commands : IScript
{
    [Command("ping")]
    public static void PingCmd(IPlayer player)
    {
        Debug.OutputDebugString("Received Ping from " + player.Id + " | " + player.SocialClubId);
    }

    //tp 123
    [Command("tp")]
    public static void TeleportToPlayer(IPlayer player, string Id)
    {
        var otherPlayer = Alt.GetAllPlayers().FirstOrDefault(x => x.Id == uint.Parse(Id));
        if (otherPlayer is null)
        {
            player.SendChatMessage("Couldn't find a Player with an ID [" + Id + "]");
            return;
        }

        player.Position = otherPlayer.Position;
        player.SendChatMessage("You have Teleported to " + otherPlayer.Name +" [" + Id + "].");
        otherPlayer.SendChatMessage("Administrator " + player.Name + " teleported to your location.");
        //player.Position = new Vector3(otherPlayer.Position.X, otherPlayer.Position.Y, otherPlayer.Position.Z);
    }    
    
    [Command("gethere")]
    public static void GetPlayerToMe(IPlayer player, string Id)
    {
        var otherPlayer = Alt.GetAllPlayers().FirstOrDefault(x => x.Id == uint.Parse(Id));
        if (otherPlayer is null)
        {
            player.SendChatMessage("Couldn't find a Player with an ID [" + Id + "]");
            return;
        }
        otherPlayer.Position = player.Position;
        player.SendChatMessage("You brought " + otherPlayer.Name +" [" + Id + "] to your self.");
        otherPlayer.SendChatMessage("Administrator " + player.Name + " teleported to you to his location.");
    }

    [Command("spawnveh")]
    public static void SpawnVehicleByName(IPlayer player, string veh)
    {
        uint hash = Alt.Hash(veh);
        Alt.CreateVehicle(Alt.Hash(veh), player.Position, player.Rotation);
        player.SendChatMessage("You spawned an " + (VehicleModel)hash);
    }

    [Command("gotocoords")]
    public static void GoToCoords(IPlayer player, int x, int y, int z)
    {
        player.Position = new Vector3(x, y, z);
    }


    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public static void OnPlayerConnect(IPlayer player, string reason)
    {
        player.Spawn(new Vector3(0,0,72), 50);
        player.Model = (uint)PedModel.Franklin;
        player.SendChatMessage("Player ID Connected: " + player.Id);
        player.SendChatMessage("Server IP: " + Dns.GetHostName());
        Debug.OutputDebugString("Server IP: " + Dns.GetHostName());
        Debug.OutputDebugString("Server Adresses: " + Dns.GetHostAddresses(Dns.GetHostName()));
        //Debug.OutputDebugString("Server AdressesJson: " + System.Text.Json.JsonSerializer.Serialize(Dns.GetHostAddresses(Dns.GetHostName())));
        foreach(var obf in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            Debug.OutputDebugString(obf.ToString());
        }
    }

    [Command("kick")]
    public static void KickPlayer(IPlayer player, uint id, string reason)
    {
        var otherPlayer = Alt.GetAllPlayers().FirstOrDefault(x => x.Id == id);
        if (otherPlayer is null)
        {
            player.SendChatMessage("Couldn't find a Player with an ID [" + Id + "]");
            return;
        }
        otherPlayer.Kick(reason);
    }
    
    [Command("ban")]
    public static void banPlayer(IPlayer player, uint id, string reason)
    {
        var otherPlayer = Alt.GetAllPlayers().FirstOrDefault(x => x.Id == id);
        if (otherPlayer is null)
        {
            player.SendChatMessage("Couldn't find a Player with an ID [" + Id + "]");
            return;
        }
        otherPlayer.Kick(reason);
    }
}