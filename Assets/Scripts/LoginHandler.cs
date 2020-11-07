using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginHandler : MonoBehaviour
{
    private Action<string> passwordReceivers ;
    private Action<string> usernameReceivers;
    private Action loginReceivers;

    public void addPasswordReceiver(Action<string> receiver) { passwordReceivers += receiver; }
    public void addusernameReceivers(Action<string> receiver) { usernameReceivers += receiver; }
    public void addLoginReceivers(Action receiver) { loginReceivers += receiver; }
    public void OnPasswordUpdate(string password) {
        if (passwordReceivers != null)
        {
            passwordReceivers.Invoke(password);

        }
        Debug.Log(password);
    }
    public void OnUsernameUpdate(string username)
    {
        if (usernameReceivers != null)
        {
            usernameReceivers.Invoke(username);
            
        }
        Debug.Log(username);
    }
    public void LoginPress() {
        Debug.Log("attempt to login in");
        if (loginReceivers != null){
            
            loginReceivers.Invoke();

        }
    }
}
