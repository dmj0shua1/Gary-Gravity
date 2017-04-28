using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PrintTimeAttack : MonoBehaviour
{

    Camera maincam;
    DateTime currentDate;
    DateChecker dateCheckerScript;
    DateTime oldDate;
    public Text timerAttack;
    public string itemName = "Attack";
    TimeSpan timeLeftAttack;
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

        if (PlayerPrefs.HasKey("endTimeAttack"))
        {
            string dT = PlayerPrefs.GetString("endTimeAttack");
            endTime = Convert.ToDateTime(dT);
            print("ENDTIME: " + endTime);
            expirationChecker();
        }
    }

    void expirationChecker()
    {
        dateCheckerScript.datevalue1 = endTime;
        dateCheckerScript.itemName = "Attack";
        dateCheckerScript.expiryCheck();
    }

    void Update()
    {


        curTime = System.DateTime.Now;
        timeLeftAttack = endTime - curTime;
        var secsLeftAttack = timeLeftAttack.TotalSeconds;



        // print("Total Hours: " + secsLeftAttack.ToString());

        string output = String.Format("{0:D2}:{1:D2}:{2:D2}", timeLeftAttack.Hours, timeLeftAttack.Minutes, timeLeftAttack.Seconds);



        if (secsLeftAttack <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Menu") timerAttack.text = "0 Attack";
            PlayerPrefs.DeleteKey("endTimeAttack");

        }
        else if (secsLeftAttack <= 60)
        {
            string secsLeftAttackStr = secsLeftAttack.ToString().Substring(0, 2);
            if (secsLeftAttack >= 10 && SceneManager.GetActiveScene().name == "Menu") timerAttack.text = "00:00:" + secsLeftAttackStr;
            else
            {
                secsLeftAttackStr = secsLeftAttack.ToString().Substring(0, 1);
                timerAttack.text = "00:00:0" + secsLeftAttackStr;
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Menu") timerAttack.text = output;
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


        PlayerPrefs.SetString("endTimeAttack", result.ToString());

        refreshTime();
    }



} 


