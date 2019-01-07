using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {
    public int health = 3;
    Animator anim;
    BoxCollider2D col;
	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
            StartCoroutine(Die());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Lightning") ) {
            health = health - 3;
        }
        if (collision.name.StartsWith("Flame")) {
            health--;
        }
    }
    IEnumerator Die()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        Debug.Log("I am already dead");
        Destroy(gameObject);
    }
}
