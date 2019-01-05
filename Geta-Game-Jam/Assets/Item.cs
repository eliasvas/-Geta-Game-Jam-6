using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    bool canPeakUp;
    public int pointsToGive = 3;
    public Text ironText;
    public Text hydroText;
    public Text mercText;
    public Text porcText;
    public int iron;
    public int hydro;
    public int merc;
    public int porc;
    SpriteRenderer sr;
    public Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = FindObjectOfType<Canvas>();
        //ironText = canvas.GetComponent("ironText") as Text;
        //hydroText = canvas.GetComponent("hydroText") as Text;
        //mercText = canvas.GetComponent("mercText") as Text;
        //porcText = canvas.GetComponent("porcText") as Text;
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X) && canPeakUp) {
            //Debug.Log("Peakup");
            StartCoroutine(PickUp());
        }
	}
    IEnumerator PickUp() {
        int val = int.Parse(ironText.text);
        val = val + iron;
        ironText.text = val.ToString();

        val = int.Parse(hydroText.text);
        val = val + hydro;
        hydroText.text = val.ToString();
        Debug.Log(hydroText.text);

        val = int.Parse(mercText.text);
        val = val + merc;
        mercText.text = val.ToString();

        val = int.Parse(porcText.text);
        val = val + porc;
        porcText.text = val.ToString();

        enabled = false;
        sr.enabled = false;
        yield return new WaitForSeconds(10);
        enabled = true;
        sr.enabled = true;
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
