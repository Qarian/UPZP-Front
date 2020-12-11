using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGIN_TEST : MonoBehaviour
{
    public LoginHandler loginHandler;
    private void Start()
    {
        loginHandler.addLoginReceivers(Login);
        loginHandler.addPasswordReceiver(UpdatePassword);
        loginHandler.addusernameReceivers(UpdateUsername);
    }
    string Password = "";
    string Username = "";
    void UpdatePassword(string Password)

    {
        Debug.Log("Username:" + Username);
        this.Password = Password;
    }
    void UpdateUsername(string Username)
    {
        Debug.Log("Password:" + Password);
        this.Username = Username;
    }
    void Login() {
        Debug.Log("Password:"+ Password);
        Debug.Log("Username:"+ Username);
    }
}
