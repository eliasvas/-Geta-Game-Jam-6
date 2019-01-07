using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Y))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.N))
            SceneManager.LoadScene(0);
	}
}
