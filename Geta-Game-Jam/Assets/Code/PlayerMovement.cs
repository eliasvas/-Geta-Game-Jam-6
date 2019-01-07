using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {

    public int speed = 1;
    public bool canMove = true;
    public Animator anim;
    bool wasIdle = false;
    AnimatorClipInfo[] m_CurrentClipInfo;
    string clipName;
    public Vector3 Direction;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        if (canMove)
        {
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Horizontal", movement.x);
            transform.position = transform.position + movement * Time.deltaTime * speed;
        }
        m_CurrentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
        clipName = (m_CurrentClipInfo[0].clip.name);
        if (clipName.EndsWith("Up"))
        {
            Direction = Vector3.up;
        }
        else if (clipName.EndsWith("Down"))
        {
            Direction = Vector3.up * (-1);
        }
        else if (clipName.EndsWith("Right"))
        {
            Direction = Vector3.right;
        }
        else {
            Direction = Vector3.right * (-1);
        }
        //Debug.Log(Direction);

    }
    public void Brew() {
        StartCoroutine(BrewNow());
    }
    IEnumerator BrewNow() {
        canMove = false;
        anim.SetTrigger("Crafting");
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }
    public void HealthUp() {
        StartCoroutine(HPNow());
    }
    IEnumerator HPNow() {
        canMove = false;
        anim.SetTrigger("HP");
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }
    public void Throw() {
        StartCoroutine(ThrowNow());
    }
    IEnumerator ThrowNow() {
        //canMove = false;
        anim.SetTrigger("Throw");
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }
}
