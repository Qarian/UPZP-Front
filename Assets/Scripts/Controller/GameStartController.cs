using Networking;

public class GameStartController : Controller
{
    public void OnOpenScene(string sceneName)
    {
        //nothing
    }

    public void Receive(Message message)
    {
        if (message.Version != 9)
            return;
    }
}
