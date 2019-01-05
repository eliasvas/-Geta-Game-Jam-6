using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngridientManager : MonoBehaviour {

    PlayerMovement playermovement;

    public Text ironText;
    public Text potText;
    public Text hydroText;
    public Text mercText;

    public Text RED;
    public Text GREEN;
    public Text BLUE;

    public int irons;
    public int pottasiums;
    public int hydros;
    public int mercs;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        playermovement = player.GetComponent<PlayerMovement>();
	}

    // Update is called once per frame
    void Update() {
        irons = int.Parse(ironText.text);
        pottasiums = int.Parse(potText.text);
        hydros = int.Parse(hydroText.text);
        mercs = int.Parse(mercText.text);
        //2I + 1POT
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J) && irons >=2 && pottasiums >=1) {
            playermovement.Brew();
            Debug.Log("Weapon1 Loaded");
            incr(ironText, -2);
            incr(potText, -1);
            incr(RED, 1);
            //DOAWESOMEMOVE1
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.K) && hydros >= 1 && mercs >= 1 && irons > 1)
        {
            playermovement.Brew();
            Debug.Log("Weapon2 Loaded");
            incr(hydroText, -2);
            incr(mercText, -1);
            incr(GREEN, 1);
            //DOAWESOMEMOVE2
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L) && hydros >= 2 && mercs>= 1)
        {
            playermovement.Brew();
            Debug.Log("Weapon3 Loaded");
            incr(hydroText, -2);
            incr(mercText, -1);
            incr(GREEN, 1);
            //DOAWESOMEMOVE3
        }
    }
    public void incr(Text t, int val) {
        int value = int.Parse(t.text);
        value += val;
        t.text = value.ToString();

    }
}
