using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDriver : MonoBehaviour {
   
   // Update is called once per frame
   void Update () {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         WarGameManager.singleton.actionDone = true;
      }
      else
      {
         WarGameManager.singleton.actionDone = false;
      }
   }
}
