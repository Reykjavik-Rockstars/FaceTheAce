using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

interface IUserName
{
    string userName{get; set;}
}

public class ClientInfo : MonoBehaviour {

    public static ClientInfo singleton;

    // The below regular expression is capable of checking for a non-empty string.
    static string unRegex = "\\b.+\\b";

    string _username;
    public string userName
    {
        get { return _username; }
        set { _username = value; }
    }

	void Awake () {
        singleton = this;
	}

    public bool IsValid()
    {
        if (_username == null) { return false; }
        Regex rx = new Regex(unRegex);
        return rx.IsMatch(_username);
    }
}
