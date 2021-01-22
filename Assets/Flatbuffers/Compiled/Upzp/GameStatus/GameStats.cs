using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityScript.Scripting.Pipeline;

namespace Upzp.GameStatus {
    public class GameStats

    {
        public List<Dictionary<uint, PlayerData>> teams;
        public Vector2d mapCenter;
        public int PCid;
        public List<int> points;
        public List<Collectable> cls;


        public GameStats(Game game)
        {
            cls = new List<Collectable>();
            for (int i = 0; i < game.BoxesLength; i++)
            {
                cls.Add(new Collectable(game.Boxes(i).Value));
            }
               points = new List<int>();
            for (int i = 0; i < game.TeamsLength; i++)
            { Team? team = game.Teams(i);
                points.Add(team.Value.Points);
                teams.Add(new Dictionary<uint, PlayerData>());
                for (int j = 0; j < team?.PlayersLength; j++) {
                    var player = team?.Players(j);
                    if (player.HasValue)
                    {
                        PlayerData playerData = new PlayerData(player.Value);
                        teams[i].Add(playerData.id, playerData);
                    }
                }
            }
        }
        public void Update(Game game)
        {
            cls.Clear();
            for (int i = 0; i < game.BoxesLength; i++)
            {
                cls.Add(new Collectable(game.Boxes(i).Value));
            }
            for (int i = 0; i < game.TeamsLength; i++)
            {
                Team? team = game.Teams(i);
                points[i] = team.Value.Points;
                for (int j = 0; j < team?.PlayersLength; j++)
                {
                    var player = team?.Players(j);

                    if (player.HasValue)
                    {
                        teams[i][player.Value.Id].Update(player.Value);
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

