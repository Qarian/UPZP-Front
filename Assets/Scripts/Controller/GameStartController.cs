using FlatBuffers;
using Upzp.GameStatus;
using Networking;
using System;
using UnityEngine;
using Mapbox.Map;
using Mapbox.Unity.Map;
using UnityEngine.SceneManagement;
using Mapbox.Examples;
using System.Runtime.InteropServices;

public class GameStartController : Controller
{
    public static GameStartController GSC = null;
    CharacterManager CM = null;
    AbstractMap map = null;
    public GameStats gameStats = null;

    public GameStartController()
    {
        if (GSC!=null)
        {
            GSC = this;
        }
    }
    public void OnOpenScene(string sceneName)
    {

    }

    public void Receive(Message message)
    {

        if (message.Version != 100)
            return;

        var buffer = new ByteBuffer(message.Payload);
        Game game = Game.GetRootAsGame(buffer);

            if (gameStats == null)
            {
            gameStats = new GameStats(game);
            GSC = this;
            ControllersManager.Instance.OpenScene("Gra");
            }
            else
            {
                gameStats.Update(game);
            }
        

    }
}
