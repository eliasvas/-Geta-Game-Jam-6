using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngridientManager : MonoBehaviour {
    public AudioSource source;
    GameObject player;
    PlayerMovement playermovement;
    Animator playerAnimator;
    Health hp;
    Transform trans;
    public AudioSource hpup;

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
    public int reds;
    public int greens;
    public int blues;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        trans = GameObject.Find("Player").transform;
        playermovement = player.GetComponent<PlayerMovement>();
        playerAnimator = player.GetComponent<Animator>();
        hp = player.GetComponent<Health>();
        hpup = Resources.Load("Getting Life Sound Effect") as AudioSource;
        //StartCoroutine(ShootLeft());
        //StartCoroutine(ShootRight());
        //StartCoroutine(ShootUp());
        //StartCoroutine(ShootDown());
    }

    // Update is called once per frame
    void Update() {

        irons = int.Parse(ironText.text);
        pottasiums = int.Parse(potText.text);
        hydros = int.Parse(hydroText.text);
        mercs = int.Parse(mercText.text);
        reds = int.Parse(RED.text);
        blues = int.Parse(BLUE.text);
        greens = int.Parse(GREEN.text);

        //2I + 1POT
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J) && irons >=2 && pottasiums >=1) {
            playermovement.Brew();
            Debug.Log("Weapon1 Loaded");
            incr(ironText, -2);
            incr(potText, -1);
            incr(RED, 1);
            //DOAWESOMEMOVE1
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.K) && hydros >= 1 && mercs >= 1 && irons >= 1)
        {
            playermovement.Brew();
            Debug.Log("Weapon2 Loaded");
            incr(hydroText, -1);
            incr(mercText, -1);
            incr(ironText, -1);
            incr(BLUE, 1);
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
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J) && reds >= 1) {
            source.Play();
            if (playermovement.Direction == Vector3.up)
            {
                playermovement.Throw();
                GameObject i = (GameObject)Instantiate(Resources.Load("FlameUp"), trans.position + new Vector3(0, 10, 0), trans.rotation);
                i.transform.parent = player.transform;
            }
            else if (playermovement.Direction == Vector3.up * (-1))
            {
                playermovement.Throw();
                GameObject i = (GameObject)Instantiate(Resources.Load("FlameDown"), trans.position + new Vector3(0,-10, 0), trans.rotation);
                i.transform.parent = player.transform;
            }
            else if (playermovement.Direction == Vector3.right)
            {
                playermovement.Throw();
                GameObject i = (GameObject)Instantiate(Resources.Load("FlameRight"), trans.position + new Vector3(40, 0, 0), trans.rotation);
                i.transform.parent = player.transform;
            }
            else if (playermovement.Direction == Vector3.right * (-1)) {
                playermovement.Throw();
                GameObject i = (GameObject)Instantiate(Resources.Load("FlameLeft"), trans.position + new Vector3(-40,0,0), trans.rotation);
                i.transform.parent = player.transform;
            }
            incr(RED, -1);
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.K) && blues >= 1)
        {
            StartCoroutine(WaitAndBreak());
            if (playermovement.Direction == Vector3.up)
            {
                playermovement.Throw();
                Instantiate(Resources.Load("LightningUp"), trans.position + new Vector3(-30, 140, 0), trans.rotation);
            }
            else if (playermovement.Direction == Vector3.up * (-1))
            {
                playermovement.Throw();
                Instantiate(Resources.Load("LightningDown"), trans.position + new Vector3(-40, 60, 0), trans.rotation);
            }
            else if (playermovement.Direction == Vector3.right)
            {
                playermovement.Throw();
                Instantiate(Resources.Load("LightningRight"), trans.position + new Vector3(50, 110, 0), trans.rotation);
            }
            else if (playermovement.Direction == Vector3.right * (-1))
            {
                playermovement.Throw();
                Instantiate(Resources.Load("LightningLeft"), trans.position + new Vector3(-50, 110, 0), trans.rotation);
            }
            incr(BLUE, -1);
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L) && greens >= 1)
        {
            //hpup.Play();
            playermovement.HealthUp();
            hp.currentHearts++;
            incr(GREEN, -1);
        }
    }
    public void incr(Text t, int val) {
        int value = int.Parse(t.text);
        value += val;
        t.text = value.ToString();

    }
    public IEnumerator ShootUp() {
        while (true)
        {
            Instantiate(Resources.Load("LightningUp"), trans.position + new Vector3(-30,140,0), trans.rotation);
            yield return new WaitForSeconds(2);
        }
    }
    public IEnumerator ShootDown()
    {
        while (true)
        {
            Instantiate(Resources.Load("LightningDown"), trans.position + new Vector3(-40, 60, 0), trans.rotation);
            yield return new WaitForSeconds(2);
        }
    }
    public IEnumerator ShootRight()
    {
        while (true)
        {
            Instantiate(Resources.Load("LightningRight"), trans.position + new Vector3(50, 110, 0), trans.rotation);
            yield return new WaitForSeconds(2);
        }
    }
    public IEnumerator WaitAndBreak() {
        yield return new WaitForSeconds(0.5f);
        source.Play();
    }
    public IEnumerator ShootLeft()
    {
        while (true)
        {
            Instantiate(Resources.Load("LightningLeft"), trans.position + new Vector3(-50, 110, 0), trans.rotation);
            yield return new WaitForSeconds(2);
        }
    }
}
