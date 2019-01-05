using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    bool canPeakUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X) && canPeakUp) {
            //open
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            Debug.Log("Yeha");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            canPeakUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            canPeakUp = false;
        }
    }
}
