using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Lightning")) {
            Debug.Log("I am dead!");
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        //anim.SetTrigger("Die");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
