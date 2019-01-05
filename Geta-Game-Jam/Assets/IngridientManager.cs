using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngridientManager : MonoBehaviour {

    public int iron = 0;
    public int pot = 0;
    public int hydro = 0;
    public int merc = 0;
    public Text ironText;
    public Text potText;
    public Text hydroText;
    public Text mercText;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        ironText.text = iron.ToString();
        potText.text = pot.ToString();
        hydroText.text = hydro.ToString();
        mercText.text = merc.ToString();
    }
}
