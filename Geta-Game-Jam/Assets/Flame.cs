using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {
    Collider2D col;
	// Use this for initialization
	void Start () {
        col = GetComponent<Collider2D>();
        StartCoroutine(SpitFire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SpitFire() {
        col.enabled = true;
        yield return new WaitForSeconds(0.5f);
        col.enabled = false;
        Destroy(gameObject);
    }
}
