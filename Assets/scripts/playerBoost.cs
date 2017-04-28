using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerBoost : MonoBehaviour {
    Animation anim;
    SwipeMovement swipeScript;
    GameObject maincam, btnPause, boostLane,btnShield,btnAttack,objBoostTornadoL,objBoostTornadoR;
    RdmObjGen rdmobj;
    cooldownBoost cooldownBoostScript;
    Sprite sprBoost, sprShield, sprAttack;
    Animator hudAnim;
	// Use this for initialization
	void Start () {
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        boostLane = GameObject.Find("BoostLane");
        maincam = GameObject.Find("Main Camera");
        anim = GameObject.FindGameObjectWithTag("character").GetComponent<Animation>();
        btnPause = GameObject.Find("Pause");
        btnShield = GameObject.Find("btnShield");
        btnAttack = GameObject.Find("btnAttack");
        cooldownBoostScript = GameObject.Find("cooldownBoost").GetComponent<cooldownBoost>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startBoost()
    {
        // collectible boost
        Button btnBoost = gameObject.GetComponent<Button>();
        btnBoost.interactable = false;

        //change button color
        sprBoost = Resources.Load<Sprite>("Sprites/UI/btnBoostGrayscale");
        sprShield = Resources.Load<Sprite>("Sprites/UI/btnShieldGrayscale");
        sprAttack = Resources.Load<Sprite>("Sprites/UI/btnAttackGrayscale");

        btnBoost.GetComponent<Image>().sprite = sprBoost;
        btnShield.GetComponent<Image>().sprite = sprShield;
        btnAttack.GetComponent<Image>().sprite = sprAttack;

        // disable buttons
        btnBoost.GetComponent<Button>().enabled = false;
        btnPause.GetComponent<Button>().interactable = false;
        btnShield.GetComponent<Button>().enabled = false;
        btnAttack.GetComponent<Button>().enabled = false;

        
       
        if (PlayerPrefs.GetString("chosenChar") == "Shopper_girl")
        {
            //turnOnTornados
            objBoostTornadoL = GameObject.Find("boostTornadoL");
            objBoostTornadoR = GameObject.Find("boostTornadoR");
            objBoostTornadoL.GetComponent<SpriteRenderer>().enabled = true;
            objBoostTornadoR.GetComponent<SpriteRenderer>().enabled = true;
        }

        hudAnim = GameObject.Find("hud").GetComponent<Animator>();
        hudAnim.SetBool("isBoosting", true);

        cooldownBoostScript.startBoost();


        
    }

}
