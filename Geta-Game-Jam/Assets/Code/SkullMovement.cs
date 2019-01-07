using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkullMovement : MonoBehaviour {

    public float speed = 100;
    Transform player;
    bool pursue = false;
    bool Dead = false;
    BoxCollider2D col;
	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (col.enabled == false)
            Dead = true;
        if (Vector2.Distance(transform.position, player.position) < 300)
            pursue = true;
        else
            pursue = false;
        if (pursue && !Dead)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}
}
