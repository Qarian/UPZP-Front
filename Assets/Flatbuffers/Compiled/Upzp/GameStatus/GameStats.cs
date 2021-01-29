using Mapbox.Utils;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityScript.Scripting.Pipeline;

namespace Upzp.GameStatus
{
    public class GameStats
    {
        public List<Dictionary<uint, PlayerData>> teams;
        public Vector2d mapCenter;
        public uint PCid;
        public int PCTeam;
        public int enemyScore = 0;
        public int allyScore = 0;
        public int playerScore = 0;
        public List<int> points;
        public List<Collectable> cls;
        public bool isUpdated = false;

  
        public GameStats(Game game)
        {
            var PC = new PlayerData(game.Teams(0).Value.Players(0).Value);
            PCid = (uint)WaitingRoomPrezenter.userID;
            mapCenter = PC.position;
            cls = new List<Collectable>();
           
            for (int i = 0; i < game.BoxesLength; i++)
            {
                cls.Add(new Collectable(game.Boxes(i).Value));
            }
            
            points = new List<int>();
            teams = new List<Dictionary<uint, PlayerData>>();
            for (int i = 0; i < game.TeamsLength; i++)

            {
 
                Team? team = game.Teams(i);
                points.Add(team.Value.Points);
                teams.Add(new Dictionary<uint, PlayerData>());
                for (int j = 0; j < team?.PlayersLength; j++) {
                    var player = team?.Players(j);
                    if (player.HasValue)
                    {
                        PlayerData playerData = new PlayerData(player.Value);
                        teams[i].Add(playerData.id, playerData);
                        if (playerData.id == PCid)
                        {
                            PCTeam = i;
                        }
                    }
                }
            }
        }
        public void Update(Game game)
        {
            isUpdated = true;
            int k;
            for (k = 0; k < game.BoxesLength; k++)
            {
                if (k < cls.Count) {
                    cls[k].Update(game.Boxes(k).Value);
                }
                else {
                    cls.Add(new Collectable(game.Boxes(k).Value));
                }
            }
            for (; k < cls.Count; k++)
            {
                cls.RemoveAt(cls.Count-1);
            }
            for (int i = 0; i < game.TeamsLength; i++)
            {

                Team? team = game.Teams(i);
                if (i == PCTeam)
                {
                    allyScore = team.Value.Points;
                }
                else {
                    enemyScore = team.Value.Points;
                }
                points[i] = team.Value.Points;

                for (int j = 0; j < team?.PlayersLength; j++)
                {
                    var player = team?.Players(j);
                    if (player.Value.Id == PCid)
                    {
                        playerScore = player.Value.Points;
                    }
                    if (j < teams[i].Count)
                    {
                        teams[i][player.Value.Id].Update(player.Value);
                    }
                    else
                    {
                        PlayerData playerData = new PlayerData(player.Value);
                        teams[i].Add(playerData.id, playerData);
                    }
 
                }
            }
        }
    }


    public class Collectable {
        public int points;
        public Vector2d position;
        public Collectable(PointBox cl)
        {
            points = cl.Value;
            position = new Vector2d(cl.Position.Value.Latitude, cl.Position.Value.Longitude);

        }
        public void Update(PointBox cl) {
            points = cl.Value;
            position = new Vector2d(cl.Position.Value.Latitude, cl.Position.Value.Longitude);
        }
    }

    public class PlayerData
    {
        public uint id;
        public string name;
        public Vector2d position;
        public Vehicle vehicle;
        public int points;

        public PlayerData(Player player)
        {   
            id = player.Id;
            name = player.Name;
            position = new Vector2d(player.Position.Value.Latitude, player.Position.Value.Longitude);
            Debug.Log(position);
            vehicle = player.Vehicle;
            points = player.Points;
        }
        public void Update(Player player)
        {
            position.Set(player.Position.Value.Latitude, player.Position.Value.Longitude);
            points = player.Points;
        }

    }
}

