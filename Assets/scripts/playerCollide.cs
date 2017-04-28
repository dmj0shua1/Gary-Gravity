using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCollide : MonoBehaviour {

   // public Collider playerCollide ;

	// Use this for initialization
    Camera cam;
    camdescend pDescend;
    GameObject character, player, goPanel, btnPause, ui, maincam, boostLane;
    Button btnShield,btnAttack,btnBoost;
    scoreCounter scoring;
    SwipeMovement swipeScript;
    Animator gameover;
    public Slider healthbarSlider,boostbarSlider;
    RdmObjGen rdmobj;
    bool invokeCollectiblesOnce = false;
    Animation anim;
    SfxPlayer sfxScript;
    boostMusic boostMusicScript;
    int tempGoldCoins, goldCoins;
    highScore hscoreScript;
    Text colCoins;
    simpleAd simpleAd;
    levelUp lvlUp;
	void Start () {
     
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        boostLane = GameObject.Find("BoostLane");
        healthbarSlider = GameObject.Find("healthSlider").GetComponent<Slider>();
        boostbarSlider = GameObject.Find("boostSlider").GetComponent<Slider>();
        ui = GameObject.Find("UI");
        maincam = GameObject.Find("Main Camera");
        cam = Camera.main;
        btnPause = GameObject.Find("Pause");
        goPanel = GameObject.Find("goPanel");
        gameover = goPanel.GetComponent<Animator>();    
        player = GameObject.FindGameObjectWithTag("Player");
        scoring = GameObject.Find("subScoreCounter").GetComponent<scoreCounter>();
        pDescend = player.gameObject.GetComponent<camdescend>();
        anim = GameObject.FindGameObjectWithTag("character").GetComponent<Animation>();
        btnShield = GameObject.Find("btnShield").GetComponent<Button>();
        btnAttack = GameObject.Find("btnAttack").GetComponent<Button>();
        btnBoost = GameObject.Find("btnBoost").GetComponent<Button>();
        PlayerPrefs.DeleteKey("tempGoldCoins");
        colCoins = GameObject.Find("txtCc").GetComponent<Text>();
        character = GameObject.FindGameObjectWithTag("character");
        lvlUp = GameObject.Find("subScoreCounter").GetComponent<levelUp>();
        swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
	}
	
	// Update is called once per frame
	void Update () {
    
      
        	}


    void OnTriggerEnter(Collider playerCollider)
    {

        if (playerCollider.gameObject.tag == "Obstacles")
        {
            // game over

            if (PlayerPrefs.GetInt("adsDisabled") == 0)
            {
                simpleAd = GameObject.Find("simpleAd").GetComponent<simpleAd>();
                simpleAd.gameOverAd();
            }


            gameover.SetBool("isGameOver", true);
            swipeScript.isGameOver = true;

            if (character.name == "Ruth2") character.GetComponent<Animation>().Play("shopper_dead_top");
            else if (character.name == "Char") character.GetComponent<Animation>().Play("gary_dead_animation");
            


            scoring.enabled = false;
          pDescend.enabled = true;
          scoring.stopScoring(true);
          btnPause.SetActive(false);
          cam.SendMessage("TurnBlurOn");
          ui.SetActive(false);

            //highscore
          hscoreScript = GameObject.Find("GameOver").GetComponent<highScore>();
          hscoreScript.CheckAndSet();

            //game over sfx
          GameObject objSfxGameOver = GameObject.Find("sfxGameOver");
          AudioSource asSfxGameOver = objSfxGameOver.GetComponent<AudioSource>();
          asSfxGameOver.Play();
          BoxCollider colPlayer = GetComponent<BoxCollider>();
          colPlayer.enabled = false;

            //addcoin from temp
          if (PlayerPrefs.HasKey("tempGoldCoins"))
          {
              tempGoldCoins = PlayerPrefs.GetInt("tempGoldCoins");
              goldCoins = PlayerPrefs.GetInt("PlayerGold");
              PlayerPrefs.SetInt("PlayerGold", goldCoins + tempGoldCoins);
            
          }

          //levelUp
          lvlUp.lvlUp();

          swipeScript.enabled = false;
        }

        else if (playerCollider.gameObject.tag == "CollectiblesCap")
        {
            // collectible capacity
            
            swipeScript.swipeCap = healthbarSlider.maxValue;
            healthbarSlider.value = healthbarSlider.maxValue;
            Destroy(playerCollider.gameObject);
            print("cap collided");

            GameObject objSfxCap = GameObject.Find("sfxCollectSwipe");
            sfxScript = objSfxCap.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesBoost")
        {
            // collectible boost

            btnBoost.interactable = true;
            rdmobj.stopBoostNow = true;
            Destroy(playerCollider.gameObject);

            GameObject objSfxBoost = GameObject.Find("sfxCollectBoost");
            sfxScript = objSfxBoost.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesShield")
        {
            // collectible shield

            btnShield.interactable = true;
            rdmobj.stopShieldNow = true;
            Destroy(playerCollider.gameObject);

            GameObject objSfxShield = GameObject.Find("sfxCollectShield");
            sfxScript = objSfxShield.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesAttack")
        {
            // collectible attack
            rdmobj.stopAttackNow = true;
            btnAttack.interactable = true;
            Destroy(playerCollider.gameObject);

            GameObject objSfxAttack = GameObject.Find("sfxCollectAttack");
            sfxScript = objSfxAttack.GetComponent<SfxPlayer>();
            sfxScript.playSfx();
        }

        else if (playerCollider.gameObject.tag == "CollectiblesCoin")
        {
            Destroy(playerCollider.gameObject);

            GameObject objSfxCoin = GameObject.Find("sfxCollectCoin");
            sfxScript = objSfxCoin.GetComponent<SfxPlayer>();
            sfxScript.playSfx();

            //addCoin from colleced
            PlayerPrefs.SetInt("tempGoldCoins", PlayerPrefs.GetInt("tempGoldCoins") + 1);

            int Cc = int.Parse(colCoins.text);
            Cc += 1;
            colCoins.text = Cc.ToString();

        }
    }

 

   

 


}
