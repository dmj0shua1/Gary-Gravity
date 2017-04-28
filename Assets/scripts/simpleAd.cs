using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class simpleAd : MonoBehaviour {

	// Use this for initialization

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            PlayerPrefs.SetInt("adsCounter",0);
        }

        if (!PlayerPrefs.HasKey("adsDisabled"))
        {
            PlayerPrefs.SetInt("adsDisabled", 0);
        }
       
    }

    public void gameOverAd()
    {
        if (PlayerPrefs.GetInt("adsCounter") <= 2 )
        {
            PlayerPrefs.SetInt("adsCounter",PlayerPrefs.GetInt("adsCounter") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("adsCounter", 0);
            ShowAd();
        }
    }

	 public void ShowAd()
  {
    if (Advertisement.IsReady())
    {
      Advertisement.Show();
    }
  }

     public void DisableAds()
     {
         PlayerPrefs.SetInt("adsDisabled", 1);
     }
	}

