using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMeshControllerTestDriver : MonoBehaviour {

   public CardMeshController controller;
   private GameObject go;

   // Spawns PlayingCard prefab object into the middle of the screen
   void Start()
   {
      go = Instantiate<GameObject>(
         Resources.Load<GameObject>("PlayingCard"),
         new Vector3(0.0f, 1.0f, 0.0f),
         new Quaternion(0.0f, 0.0f, 0.0f, 1.0f)
      );
      go.transform.Rotate(-90.0f, 0.0f, 0.0f);
   }

   // Press space bar, card changes to different card rank and suit
   void Update()
   {
      // Test mesh changer
      if (Input.GetKeyDown(KeyCode.Space))
      {
         var val = Random.Range(0, 53);
         Debug.Log("index val: " + val);
         controller.ChangeCardMesh(go, val);
         //controller.ChangeCardMesh(go, controller.GetCardIndex(Rank.Ace, Suit.Club));
      }
   }

}
