using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cooldownBoost : MonoBehaviour {


     SwipeMovement swipeScript;
     GameObject character, player, goPanel, btnPause, ui, maincam, boostLane, objBoostTornadoL, objBoostTornadoR,explosion;
     public Slider boostbarSlider;
     RdmObjGen rdmobj;
      bool invokeCollectiblesOnce = false;
      Button btnShield, btnAttack, btnBoost;
      boostMusic boostMusicScript;
      Animation anim;
      Sprite sprBoost, sprShield, sprAttack;
      Animator boostFlashAnim,hudAnim;
      AudioSource sfxExplosion;
      GameObject boostProps;
      boostProp boostPropScript;
	// Use this for initialization
	void Start () {
        boostLane = GameObject.Find("BoostLane");
        btnShield = GameObject.Find("btnShield").GetComponent<Button>();
        btnAttack = GameObject.Find("btnAttack").GetComponent<Button>();
        btnBoost = GameObject.Find("btnBoost").GetComponent<Button>();
        btnPause = GameObject.Find("Pause");
        maincam = GameObject.Find("Main Camera");
        swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
        boostPropScript = GameObject.FindGameObjectWithTag("Player").GetComponent<boostProp>();
        boostProps = boostPropScript.objBoostProp;
	}
	
	// Update is called once per frame
	void Update () {


        //declarations
        character = GameObject.FindGameObjectWithTag("character");
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        anim = character.GetComponent<Animation>();

        if (boostbarSlider.value == boostbarSlider.maxValue)
        {

            if (!invokeCollectiblesOnce)
            {
                rdmobj.invokeCollectibles = true;
                invokeCollectiblesOnce = true;
            }
            //change button color
            sprBoost = Resources.Load<Sprite>("Sprites/UI/btnBoost");
            btnBoost.GetComponent<Image>().sprite = sprBoost;
        }
        else
        {
            //change button color
            sprBoost = Resources.Load<Sprite>("Sprites/UI/btnBoostGrayscale");
            btnBoost.GetComponent<Image>().sprite = sprBoost;
        }

        if (boostbarSlider.value <= 0f)
        {

            regenBoost();
        }
	}

    void regenBoost()
    {

        InvokeRepeating("regenBoostInvoked", 4, 4);
        
    }

    void regenBoostInvoked()
    {

        if (boostbarSlider.value >= boostbarSlider.maxValue)
        {
            rdmobj.stopBoostNow = false;
            CancelInvoke("regenBoostInvoked");
           
        }
        else
        {
            boostbarSlider.value += 0.005f;
            swipeScript.boostCap += 0.005f;
            invokeCollectiblesOnce = !invokeCollectiblesOnce;
           
        }
    }
         public void startBoost()
    {
        if (character.name == "Ruth2") anim.CrossFade("shopper_girl_spin");
        else if (character.name == "Char") {
            anim.CrossFade("gary_boost_animation");     
            boostProps.SetActive(true);
            boostPropScript.objIdleProp.SetActive(false);
            Animation hose_anim = boostProps.GetComponent<Animation>();
        
            
         }
       
        swipeScript.targetPosition = boostLane.transform.position;
        Time.timeScale = 4f;
        InvokeRepeating("decBoost", 4, 4);

        // disable buttons
        btnPause.GetComponent<Button>().interactable = false;
        btnBoost.GetComponent<Button>().enabled = false;
        btnShield.GetComponent<Button>().enabled = false;
        btnAttack.GetComponent<Button>().enabled = false;


    }

    void Unboost()
    {
        swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
        swipeScript.currentLane = "Lane2";
        swipeScript.targetPosition = swipeScript.target2.transform.position;
    
        Time.timeScale = 1f;
        //destroy all obstacles
        GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacles");
        sfxExplosion = GameObject.Find("sfxDestroyedByAttack").GetComponent<AudioSource>();
        explosion = (GameObject)Resources.Load("Visuals/attackExplosion", typeof(GameObject));

        foreach (GameObject ob in obs)
        {
            Destroy(ob);
            sfxExplosion.Play();
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }

        //destroy collectiblecaps
        GameObject[] obscap = GameObject.FindGameObjectsWithTag("CollectiblesCap");
        foreach (GameObject obcap in obscap)
        {
            Destroy(obcap);
        }

        //destroy collectibleboost
        GameObject[] obsboost = GameObject.FindGameObjectsWithTag("CollectiblesBoost");
        foreach (GameObject obboost in obsboost)
        {
            Destroy(obboost);
        }

        //enable buttons
        btnPause.GetComponent<Button>().interactable = true;
        btnBoost.GetComponent<Button>().enabled = true;
        btnShield.GetComponent<Button>().enabled = true;
        btnAttack.GetComponent<Button>().enabled = true;
        hudAnim = GameObject.Find("hud").GetComponent<Animator>();
        hudAnim.SetBool("isBoosting", false);

        //change button color
      /*  sprBoost = Resources.Load<Sprite>("Sprites/UI/btnBoost");
        sprShield = Resources.Load<Sprite>("Sprites/UI/btnShield");
        sprAttack = Resources.Load<Sprite>("Sprites/UI/btnAttack");*/

     /*   btnBoost.GetComponent<Image>().sprite = sprBoost;
        btnShield.GetComponent<Image>().sprite = sprShield;
        btnAttack.GetComponent<Image>().sprite = sprAttack;*/

        if (PlayerPrefs.GetString("chosenChar") == "Shopper_girl")
        {
            //turnOffTornados
            objBoostTornadoL = GameObject.Find("boostTornadoL");
            objBoostTornadoR = GameObject.Find("boostTornadoR");
            objBoostTornadoL.GetComponent<SpriteRenderer>().enabled = false;
            objBoostTornadoR.GetComponent<SpriteRenderer>().enabled = false;

            anim.CrossFade("shopper_idle_anim_001");
        }
        else if (PlayerPrefs.GetString("chosenChar") == "Fireman")
        {
            boostProps.SetActive(false);
            boostPropScript.objIdleProp.SetActive(true);

            anim.CrossFade("gary_idle_anim");  
        }

        //stop boost music
        GameObject objboostMusic = GameObject.Find("btnBoost");
        boostMusicScript = objboostMusic.GetComponent<boostMusic>();
        boostMusicScript.stopBoostMusic();

        //disable boostprops

       
    }

      void decBoost()
    {
        if (swipeScript.boostCap > 0f)
        {
            swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
            swipeScript.boostCap -= 0.5f;
            boostbarSlider.value -= 0.5f;
        }else 
        {
            //regenBoostNow = true;
            CancelInvoke("decBoost");
            Unboost();
        }
    }
}
