using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkullMovement : MonoBehaviour {

    public float secs;
    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
        StartCoroutine(Shoot());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Shoot() {
        
        yield return new WaitForSeconds(secs);
    }
}
