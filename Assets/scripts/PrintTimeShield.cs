using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PrintTimeShield : MonoBehaviour
{

    Camera maincam;
    DateTime currentDate;
    DateChecker dateCheckerScript;
    DateTime oldDate;
    public Text timerShield;
    public string itemName = "Shield";
    TimeSpan timeLeftShield;
    DateTime endTime, curTime;
    public double itmTime;
    long temp;



    void Start()
    {
        maincam = Camera.main;
        dateCheckerScript = maincam.gameObject.GetComponent<DateChecker>();

        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        refreshTime();


    }

    public void refreshTime()
    {
        //Grab the old time from the player prefs as a long
        if (PlayerPrefs.HasKey("sysString"))
        {
            temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        }
        else
        {
            PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

        }

        //Convert the old time from binary to a DataTime variable
        oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);



        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        //    print("Difference: " + difference);
        //check if timeleft is present
        if (PlayerPrefs.HasKey("timeLeft"))
        {
            //do nothing
        }
        else
        {
            //PlayerPrefs.SetString("")
        }

        if (PlayerPrefs.HasKey("endTimeShield"))
        {
            string dT = PlayerPrefs.GetString("endTimeShield");
            endTime = Convert.ToDateTime(dT);
            print("ENDTIME: " + endTime);
            expirationChecker();
        }
    }

    void expirationChecker()
    {
        dateCheckerScript.datevalue1 = endTime;
        dateCheckerScript.itemName = "Shield";
        dateCheckerScript.expiryCheck();
    }

    void Update()
    {


        curTime = System.DateTime.Now;
        timeLeftShield = endTime - curTime;
        var secsLeftShield = timeLeftShield.TotalSeconds;



        // print("Total Hours: " + secsLeftShield.ToString());

        string output = String.Format("{0:D2}:{1:D2}:{2:D2}", timeLeftShield.Hours, timeLeftShield.Minutes, timeLeftShield.Seconds);



        if (secsLeftShield <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Menu") timerShield.text = "0 Shield";
            PlayerPrefs.DeleteKey("endTimeShield");

        }
        else if (secsLeftShield <= 60)
        {
            string secsLeftShieldStr = secsLeftShield.ToString().Substring(0, 2);
            if (secsLeftShield >= 10 && SceneManager.GetActiveScene().name == "Menu") timerShield.text = "00:00:" + secsLeftShieldStr;
            else
            {
                secsLeftShieldStr = secsLeftShield.ToString().Substring(0, 1);
                timerShield.text = "00:00:0" + secsLeftShieldStr;
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Menu") timerShield.text = output;
            print("");
        }


    }
    void OnApplicationQuit()
    {
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

        //   print("Saving this date to prefs: " + System.DateTime.Now);

    }

    public void iprintna()
    {



        System.DateTime today = System.DateTime.Now;
        System.TimeSpan duration = new System.TimeSpan(0, 0, Convert.ToInt32(itmTime), 0);
        System.DateTime result = today.Add(duration);


        PlayerPrefs.SetString("endTimeShield", result.ToString());

        refreshTime();
    }



}


