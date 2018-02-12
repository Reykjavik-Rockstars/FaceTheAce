using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

interface IIPChecker
{
    bool CheckIPAddress(string ip);
}

interface IIPHolder
{
    string ipAddress { get; set; }
}

public class IPSystem : MonoBehaviour, IIPChecker, IIPHolder {

    public static IPSystem singleton;

    // The below regular expression is capable of checking for a valid IPv4 address.
    static string ipRegex = "\\b((25[0-5]|2[0-4]\\d|[01]?\\d{1,2})\\.){3}(25[0-5]|2[0-4]\\d|[01]?\\d{1,2})/?(\\d{1,4})?\\b";

    //Setting ipAddress will trigger it to check if the set value is an IP address. It will not accept invalid IP addresses.
    string _ipAddress = "invalid";
    public string ipAddress
    {
        get
        {
            return _ipAddress;
        }

        set
        {
            if (CheckIPAddress(value))
            {
                _ipAddress = value;
                //Debug.Log(message: "Valid IP Address: " + _ipAddress);
            }
            else
            {
                //Debug.LogError(message: "Error: Invalid IP Address: " + value);
            }
        }
    }

    void Awake()
    {
        singleton = this;
    }

    //The input string is checked to see if it matches an IPv4 address using the ipRegex string.
    public bool CheckIPAddress(string newIP)
    {
        Regex rx = new Regex(ipRegex);
        return rx.IsMatch(newIP);
    }

    public bool IsValid()
    {
        if (_ipAddress == null) { return false; }
        Regex rx = new Regex(ipRegex);
        return rx.IsMatch(_ipAddress);
    }
}
