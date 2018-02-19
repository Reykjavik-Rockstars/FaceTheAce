using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour {

   // Use this for initialization
   void Start () {
      
   }
   
   // Update is called once per frame
   void LateUpdate () {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      transform.Translate(new Vector3(0, moveVertical * 0.005f, 0), Space.World);
      if (moveVertical > 0)
      {

      }
   }
}
