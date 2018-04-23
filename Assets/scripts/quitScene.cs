using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class quitScene : MonoBehaviour
{
    public void quitOnClick()
    {
        Debug.Log("app has quit");
        Application.Quit();
    }
}