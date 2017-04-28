using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class BuyItem : MonoBehaviour {
    public string itemName;
    public int itemPrice,playerGold;
    public double itemTime;
    private double tempItemTime = 0;
    public Text curGold;
  //  public string itmTime;
    public PrintTimeBoost printTimeBoost;
    public PrintTimeAttack printTimeAttack;
    public PrintTimeShield printTimeShield;
    public GameObject _printTime,buyNotif;
    PlayerGold pGold;




	// Use this for initialization
	void Start () {
        _printTime = GameObject.Find("timerPrinter"+itemName);
      //  gameObject.SendMessage("itemTime", 69);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void buyItem()
    {
        playerGold = PlayerPrefs.GetInt("PlayerGold");
                //check player gold
            if (playerGold >= itemPrice)
            {
   

                //play audio
                GameObject objSfxPurchasing = GameObject.Find("sfxPurchasing");
                AudioSource asSfxPuchasing = objSfxPurchasing.GetComponent<AudioSource>();
                asSfxPuchasing.Play();

                buyNotif.SetActive(true);

                //check if player has this item already

                if (itemTime <= 480)
                {
                    if ((PlayerPrefs.HasKey("endTime" + itemName)))
                    {
                        print("BEFORE: " + itemTime.ToString());
                        if (tempItemTime == 0) tempItemTime = itemTime;
                        itemTime = (Convert.ToDateTime(PlayerPrefs.GetString("endTime" + itemName)) - System.DateTime.Now).TotalMinutes + tempItemTime;
                        print("AFTER: " + itemTime.ToString());
                    }


                    if (itemName == "Boost") {
                        printTimeBoost = _printTime.GetComponent<PrintTimeBoost>();
                        printTimeBoost.itmTime = itemTime;
                        printTimeBoost.itemName = itemName;
                        printTimeBoost.iprintna();
                    }
                    else if (itemName == "Attack")
                    {
                        printTimeAttack = _printTime.GetComponent<PrintTimeAttack>();
                        printTimeAttack.itmTime = itemTime;
                        printTimeAttack.itemName = itemName;
                        printTimeAttack.iprintna();
                    }
                    else
                    {
                        printTimeShield = _printTime.GetComponent<PrintTimeShield>();
                        printTimeShield.itmTime = itemTime;
                        printTimeShield.itemName = itemName;
                        printTimeShield.iprintna();
                    }
       
                //decrease price from gold
                PlayerPrefs.SetInt("PlayerGold", PlayerPrefs.GetInt("PlayerGold") - itemPrice);
                //curGold.text = PlayerPrefs.GetInt("PlayerGold").ToString();
                pGold = GameObject.Find("PlayerGold").GetComponent<PlayerGold>();
                pGold.playerGold = PlayerPrefs.GetInt("PlayerGold");
                PlayerPrefs.Save();
          
                }
            }
            else
            {
                //insufficient
                print("Insufficient Gold");

                //play audio
                GameObject objSfxInsufficientGold = GameObject.Find("sfxInsufficientGold");
                AudioSource asSfxInsufficientGold = objSfxInsufficientGold.GetComponent<AudioSource>();
                asSfxInsufficientGold.Play();
            }
        
       
    }

   
}

