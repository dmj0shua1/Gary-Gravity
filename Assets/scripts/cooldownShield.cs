using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cooldownShield : MonoBehaviour {


     SwipeMovement swipeScript;
     GameObject character, player, goPanel, btnPause, ui, maincam, ShieldLane;
     public Slider ShieldbarSlider;
     RdmObjGen rdmobj;
      bool invokeCollectiblesOnce = false;
      Button btnBoost, btnAttack, btnShield;
    //  ShieldMusic ShieldMusicScript;
      Animation anim;
      Sprite sprShield;
	// Use this for initialization
	void Start () {
        maincam = Camera.main.gameObject;
        ShieldLane = GameObject.Find("ShieldLane");
        btnBoost = GameObject.Find("btnBoost").GetComponent<Button>();
        btnAttack = GameObject.Find("btnAttack").GetComponent<Button>();
        btnShield = GameObject.Find("btnShield").GetComponent<Button>();
        btnPause = GameObject.Find("Pause");
        swipeScript = maincam.GetComponent<SwipeMovement>();
	}
	
	// Update is called once per frame
	void Update () {


        //declarations
        character = GameObject.FindGameObjectWithTag("character");
        maincam = GameObject.Find("Main Camera");
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        anim = character.GetComponent<Animation>();

        if (ShieldbarSlider.value == ShieldbarSlider.maxValue)
        {

            //change button color
            sprShield = Resources.Load<Sprite>("Sprites/UI/btnShield");
            btnShield.GetComponent<Image>().sprite = sprShield;
        }
        else
        {
            //change button color
            sprShield = Resources.Load<Sprite>("Sprites/UI/btnShieldGrayscale");
            btnShield.GetComponent<Image>().sprite = sprShield;
        }

        if (ShieldbarSlider.value <= 0f)
        {

            regenShield();
        }
	}

    void regenShield()
    {

        InvokeRepeating("regenShieldInvoked", 4, 4);
        
    }

    void regenShieldInvoked()
    {

        if (ShieldbarSlider.value >= ShieldbarSlider.maxValue)
        {
            rdmobj.stopShieldNow = false;
            CancelInvoke("regenShieldInvoked");
        }
        else
        {
            ShieldbarSlider.value += 0.005f;
            swipeScript.shieldCap += 0.005f;
          //invokeCollectiblesOnce = !invokeCollectiblesOnce;
        }
    }

    public void decShield()
    {
        ShieldbarSlider.value = 0f;
        swipeScript.shieldCap = 0f;
        regenShield();
    }
      

  

  
}
