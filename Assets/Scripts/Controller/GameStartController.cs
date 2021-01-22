using FlatBuffers;
using Upzp.GameStatus;
using Networking;
using System;
using UnityEngine;
using Mapbox.Map;
using Mapbox.Unity.Map;

public class GameStartController : Controller
{ CharacterManager CM = null;
    AbstractMap map = null;
    GameStats gameStats = null;
    public void OnOpenScene(string sceneName)
    {
      if (sceneName.Equals("Gra"))
        {
            map = GameObject.FindObjectOfType<AbstractMap>();
            CM = GameObject.FindObjectOfType<CharacterManager>();
        }
    }

    public void Receive(Message message)
    {
        if (message.Version != 100)
            return;

        var buffer = new ByteBuffer(message.Payload);
        Game game = Game.GetRootAsGame(buffer);
        if (map != null)
        {
            if (gameStats == null)
            {
                gameStats = new GameStats(game);
                map.Initialize(gameStats.mapCenter, map.AbsoluteZoom);
                CM.Initialize(gameStats);
            }
            else
            {
                gameStats.Update(game);
                CM.UpdateChrachters(gameStats);
            }
        }

    }
}
