using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This button does nothing but open the next scene.
public class GameIntroButton : MonoBehaviour {

	public void TaskOnPush()
    {
        SceneManager.LoadScene("IPScreen");
    }

}
