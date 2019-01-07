using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public Animator playerAnimator;
    public SpriteRenderer[] hearts;
    int maxHearts = 3;
    public int currentHearts = 3;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playermovement = player.GetComponent<PlayerMovement>();
        playerAnimator = playermovement.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHearts > maxHearts)
            currentHearts = maxHearts;
        if (currentHearts <= 0) {
            StartCoroutine(Die());
        }
        for (int i = 0; i < maxHearts; ++i) {
            if (i < currentHearts) {
                hearts[i].enabled = true;
            }else {
                hearts[i].enabled = false;
            }
        }
	}
    IEnumerator Die() {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playermovement = player.GetComponent<PlayerMovement>();
        Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
        playerRb.velocity = new Vector3(0, 0, 0);
        playermovement.canMove = false;
        playerAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
