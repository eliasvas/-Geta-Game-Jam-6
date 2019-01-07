using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kills : MonoBehaviour {
    GameObject player;
    bool canHit = true;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && canHit) {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.currentHearts--;
            canHit = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            StartCoroutine(RestoreCanHit());
        }
    }
    IEnumerator RestoreCanHit()
    {
        yield return new WaitForSeconds(1);
        canHit = true;
    }
}
