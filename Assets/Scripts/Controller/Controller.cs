using Networking;

public interface Controller
{
    void OnOpenScene(string sceneName);

    void Receive(Message message);
}
