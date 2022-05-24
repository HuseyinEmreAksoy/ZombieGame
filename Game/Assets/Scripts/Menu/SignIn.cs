using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

public class SignIn : MonoBehaviour
{
    public InputField username;
    public InputField password;
    private string Username;
    private string Password;
    private string form;
    public Button LoginButton;

    private string[] Usernames = new string[125];
    private string[] Passwords = new string[125];

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(() => {

            Username = username.GetComponent<InputField>().text;
            Debug.Log(Username);
            Password = password.GetComponent<InputField>().text;
            Debug.Log(Password);
            isValid();
        });
        TestGet();
    }
    public async void TestGet()
    {
        var url = "https://eu-api.backendless.com/9D6F17AD-F0C0-845D-FF31-360D7DB1FB00/630D15B2-4B67-407D-8108-5C3095D9E533/data/Login";
        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();
        while (!operation.isDone)
            await System.Threading.Tasks.Task.Yield();
        form = www.downloadHandler.text;

        try
        {
            //Debug.Log($"Success: {www.downloadHandler.text}");
        }
        catch (Exception e)
        {
            Debug.Log($"Failed: {www.error}");
        }
    }
    private void isValid()
    {
        int j = 0;
        string temp = form;
        string temp3 = form;
        for (int i = 0; i < form.Length; i++)
        {
            if (temp.IndexOf("Username") != -1)
            {
                Usernames[j] = temp.Substring(temp.IndexOf("Username") + 11, temp.Substring(temp.IndexOf("Username") + 11).IndexOf(",") - 1);
                temp = temp.Substring(temp.IndexOf("Username") + 11);

                Passwords[j] = temp3.Substring(temp3.IndexOf("UserPassword") + 15, temp3.Substring(temp3.IndexOf("UserPassword") + 15).IndexOf(",") - 1);
                temp3 = temp3.Substring(temp3.IndexOf("UserPassword") + 15);
                j++;
            }
            else
                break;
        }
        for (int i = 0; i < j; i++)
        {
            if (Usernames[i].Equals(Username))
            {
                Debug.Log("basarili");
            }
            else
                Debug.Log("Invalid Username or Password");

            Debug.Log("names: a" + Usernames[i] + "a\n");
            Debug.Log("Password: " + Passwords[i] + "\n");

        }
    }


}
