using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameInitializer : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GameController.singleton.MainGameStart();
        GameInfo.singleton.MainSceneStart();
        FSM.singleton.MainGameStart();
        Destroy(gameObject);
	}
}
