using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginHandler : MonoBehaviour
{
    private string username;
    private string password;
    private Action<string, string> loginReceivers;

    public void addLoginReceivers(Action<string, string> receiver)
    {
        loginReceivers += receiver;
    }
    
    public void OnPasswordUpdate(string password)
    {
        this.password = password;
    }
    
    public void OnUsernameUpdate(string username)
    {
        this.username = username;
    }
    
    public void LoginPress()
    {
        Debug.Log("attempt to login in");
        if (loginReceivers != null)
        {
            loginReceivers.Invoke(username, password);
        }
        else
        {
            Debug.Log("no assigned login events");
        }
    }
}
