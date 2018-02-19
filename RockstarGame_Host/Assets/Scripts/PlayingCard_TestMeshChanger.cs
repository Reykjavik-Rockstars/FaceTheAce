using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanger : MonoBehaviour {

   public Mesh[] mMeshes;
   private MeshFilter mFilter;

	// Use this for initialization
	void Start () {
      mFilter = GetComponent<MeshFilter>();
	}
	
	// Update is called once per frame
	void Update () {
      if (Input.GetKeyDown(KeyCode.Space))
         mFilter.mesh = mMeshes[Random.Range(0, mMeshes.Length)];
	}
}
