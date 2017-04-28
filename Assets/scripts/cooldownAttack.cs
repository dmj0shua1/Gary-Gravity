using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cooldownAttack : MonoBehaviour {


     SwipeMovement swipeScript;
     GameObject character, player, goPanel, btnPause, ui, maincam;
     public Slider AttackbarSlider;
     RdmObjGen rdmobj;
      bool invokeCollectiblesOnce = false;
      Button btnBoost, btnAttack, btnShield;
    //  AttackMusic AttackMusicScript;
      Animation anim;
      Sprite sprAttack;
	// Use this for initialization
	void Start () {
        maincam = Camera.main.gameObject;
        btnShield = GameObject.Find("btnShield").GetComponent<Button>();
        btnAttack = GameObject.Find("btnAttack").GetComponent<Button>();
        btnBoost = GameObject.Find("btnBoost").GetComponent<Button>();
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
        if (AttackbarSlider.value == AttackbarSlider.maxValue)
        {

            //change button color
            sprAttack = Resources.Load<Sprite>("Sprites/UI/btnAttack");
            btnAttack.GetComponent<Image>().sprite = sprAttack;
        }
        else
        {
            //change button color
            sprAttack = Resources.Load<Sprite>("Sprites/UI/btnAttackGrayscale");
            btnAttack.GetComponent<Image>().sprite = sprAttack;
        }

        if (AttackbarSlider.value <= 0f)
        {

            regenAttack();
        }
 
	}

    void regenAttack()
    {

        InvokeRepeating("regenAttackInvoked", 4, 4);
        
    }

    void regenAttackInvoked()
    {

        if (AttackbarSlider.value >= AttackbarSlider.maxValue)
        {
            rdmobj.stopAttackNow = false;
            CancelInvoke("regenAttackInvoked");
        
        }
        else
        {
            AttackbarSlider.value += 0.005f;
            swipeScript.attackCap += 0.005f;
          //invokeCollectiblesOnce = !invokeCollectiblesOnce;
         
        }
    }

    public void decAttack()
    {
        AttackbarSlider.value = 0f;
        swipeScript.attackCap = 0f;
        regenAttack();
    }
      

  

  
}
