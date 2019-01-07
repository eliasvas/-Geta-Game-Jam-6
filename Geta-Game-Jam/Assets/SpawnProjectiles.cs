using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour {
    BoxCollider2D col;
	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider2D>();
        StartCoroutine(Spawn());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Spawn() {
        while (true) {
            col.enabled = false;
            GameObject i = (GameObject)Instantiate(Resources.Load("Projectile"), transform.position + new Vector3(10,0,0), transform.rotation);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), i.GetComponent<BoxCollider2D>());
            col.enabled = true;
            Rigidbody2D rb = i.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(30, 0, 0);
            col.enabled = false;

            GameObject i2 = (GameObject)Instantiate(Resources.Load("Projectile"), transform.position + new Vector3(-10, 0, 0), transform.rotation);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), i2.GetComponent<BoxCollider2D>());
            col.enabled = true;
            Rigidbody2D rb2 = i2.GetComponent<Rigidbody2D>();
            rb2.velocity = new Vector3(-30, 0, 0);
            col.enabled = false;
            GameObject i3 = (GameObject)Instantiate(Resources.Load("Projectile"), transform.position , transform.rotation);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), i3.GetComponent<BoxCollider2D>());
            col.enabled = true;
            Rigidbody2D rb3 = i3.GetComponent<Rigidbody2D>();
            rb3.velocity = new Vector3(0, 30, 0);
            GameObject i4 = (GameObject)Instantiate(Resources.Load("Projectile"), transform.position, transform.rotation);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), i4.GetComponent<BoxCollider2D>());
            col.enabled = true;
            Rigidbody2D rb4 = i4.GetComponent<Rigidbody2D>();
            rb4.velocity = new Vector3(0, -30, 0);
            //i.transform.parent = transform;
            yield return new WaitForSeconds(2f);
            Destroy(i);
            Destroy(i2);
        }
        
    }
}
