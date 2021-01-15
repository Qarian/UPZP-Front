using System;
using System.Collections.Generic;
using Networking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllersManager : MonoBehaviour
{
    public static ControllersManager Instance;
    
    private List<Controller> allControllers = new List<Controller>();

    private string nextSceneToOpen;
    private bool openNextScene = false;
    
    private void Awake()
    {
        Instance = this;
        InitializeControllers();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (openNextScene)
            OpenScene();
    }

    private void InitializeControllers()
    {
        Communication.Listeners += message => { Debug.Log(message.Version); };
        allControllers.Add(new LoginController());
        allControllers.Add(new GamesListController());
        allControllers.Add(new GameInfoController());
        allControllers.Add(new WaitingRoomController());
        allControllers.Add(new GameStartController());
        foreach (Controller controller in allControllers)
        {
            Communication.Listeners += controller.Receive;
        }
    }

    public void OpenScene(string sceneName)
    {
        if (nextSceneToOpen == sceneName)
            return;
        nextSceneToOpen = sceneName;
        openNextScene = true;
    }
    
    private void OpenScene()
    {
        var operation = SceneManager.LoadSceneAsync(nextSceneToOpen);
        operation.completed += asyncOperation =>
        {
            foreach (Controller controller in allControllers)
            {
                controller.OnOpenScene(nextSceneToOpen);
            }
        };
        openNextScene = false;
    }
}
