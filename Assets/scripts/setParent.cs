using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.Find("Canvas");
        gameObject.transform.SetParent(obj.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
