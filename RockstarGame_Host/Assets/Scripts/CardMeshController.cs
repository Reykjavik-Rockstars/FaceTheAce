using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMeshController : MonoBehaviour {

   // 0th index is the card face down!
   // 0: back face of card
   // 1: Ace, Club
   // 2: Ace, Diamond
   // 3: Ace, Heart
   // 4: Ace, Spades
   // 5: 2, Club
   // 6: 2, Diamond
   // 7: ...

   // Meshes that changes the card rank and suit
   private Mesh[] Meshes;
   // single Material that holds ALL cards
   private Material Material;
   public enum Suit
   {
      Club = 1,
      Diamond = 2,
      Heart = 3,
      Spades = 4
   }
   public enum Rank
   {
      Ace = 1,
      Two = 2,
      Three = 3,
      Four = 4,
      Five = 5,
      Six = 6,
      Seven = 7,
      Eight = 8,
      Nine = 9,
      Jack = 10,
      Queen = 11,
      King = 12
   }

   void Start()
   {
      Meshes = Resources.LoadAll<Mesh>("CardMeshes");
      Material = Resources.Load<Material>("CardMaterial/Cards_Texture_Free");
   }

   /// <summary>
   /// Returns the index of the desired card.
   /// </summary>
   /// <param name="suit"></param>
   /// <param name="rank"></param>
   /// <returns>
   /// Index of the mesh
   /// 0: back face of card
   /// 1: Ace, Club
   /// 2: Ace, Diamond
   /// 3: Ace, Heart
   /// 4: Ace, Spades
   /// 5: 2, Club
   /// 6: 2, Diamond</returns>
   public int GetCardIndex(Rank rank, Suit suit)
   {
      return (4 * (int)rank) + (int)suit;
   }

   /// <summary>
   /// Changes the mesh of a card GameObject.
   /// </summary>
   /// <param name="card">The card GameObject whose mesh will be changed.</param>
   /// <param name="index">
   /// Index of the mesh
   /// 0: back face of card
   /// 1: Ace, Club
   /// 2: Ace, Diamond
   /// 3: Ace, Heart
   /// 4: Ace, Spades
   /// 5: 2, Club
   /// 6: 2, Diamond
   /// 7: ...</param>
   public void ChangeCardMesh(GameObject card, int index)
   {
      Material m = card.GetComponent<Material>();
      m = Material;
      MeshFilter mf = card.GetComponent<MeshFilter>();
      if (index < 0 || index > Meshes.Length-1)
         mf.mesh = Meshes[0];
      else
         mf.mesh = Meshes[index];
   }
}
