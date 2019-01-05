using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {
    Animator an;
    bool tab = false;
	// Use this for initialization
	void Start () {
        an = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            tab = !tab;
            an.SetBool("Tab", tab);
        }
	}
}
