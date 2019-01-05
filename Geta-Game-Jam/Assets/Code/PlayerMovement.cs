using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int speed = 1;
    public bool canMove = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        
        //Animator.setFloat("Vertical", movement.x);
        //Animator.setFloat("Horizontal", movement.y);
        transform.position = transform.position + movement * Time.deltaTime * speed;

        
	}
    public void Brew() {
        StartCoroutine(BrewNow());
    }
    IEnumerator BrewNow() {
        canMove = false;
        //anim.SetTrigger("Brew");
        yield return new WaitForSeconds(1);
        canMove = true;
    }
}
