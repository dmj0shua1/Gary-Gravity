using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class btnTimersScript : MonoBehaviour {

    public GameObject timersPanel,objBtnTimers; //  1. declare the object that contains the animation
    public Sprite timerCollapse, timerRestore;
    Animator anim;  // 2. declare a name for the animator
    Image btnSprite;
    public bool isShown;
    btnTimersScript timerScript;


	void Start () {
        isShown = false;
        objBtnTimers = GameObject.Find("btnTimers");
        btnSprite = objBtnTimers.GetComponent<Image>();
        timerScript = objBtnTimers.GetComponent<btnTimersScript>();
        anim = timersPanel.GetComponent<Animator>();  // 3. do this to get the animation from object to animator variable
	}
	

	void Update () {
	
	}


    public void showTimers()
    {
        if (isShown == false)
        {
            btnSprite.sprite = timerRestore;
            isShown = true; 
            anim.SetBool("showTimers", true); // 4. do this to modify a boolean parameter condition from the Animator
            
        }
        else
        {
            btnSprite.sprite = timerCollapse;
            isShown = false;
            anim.SetBool("showTimers", false);
            
        }
    }

    public void showTimersFromShop()
    {
        if (isShown == false)
        {
            btnSprite.sprite = timerRestore;
            timerScript.isShown = true;
            anim.SetBool("showTimers", true); // 4. do this to modify a boolean parameter condition from the Animator

        }
    }
}
