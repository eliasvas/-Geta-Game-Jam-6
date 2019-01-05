using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public SpriteRenderer[] hearts;
    int maxHearts = 3;
    public int currentHearts = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < maxHearts; ++i) {
            if (i < currentHearts) {
                hearts[i].enabled = true;
            }else {
                hearts[i].enabled = false;
            }
        }
	}
}
