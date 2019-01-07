using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningbehaviour : MonoBehaviour {

    BoxCollider2D col;

	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;
        StartCoroutine(Thunder());
	}
	
	// Update is called once per frame
	void Update () {
        if (col.enabled == true) {
        }
	}
    IEnumerator Thunder() {
        yield return new WaitForSeconds(0.3f);
        col.enabled = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
