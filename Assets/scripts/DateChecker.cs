using UnityEngine;
using System.Collections;
using System;

public class DateChecker : MonoBehaviour {

    public System.DateTime datevalue1;
    public string itemName;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void expiryCheck()
    {
        System.DateTime datevalue2 = System.DateTime.Now;
        double hours = (datevalue1 - datevalue2).TotalHours;

        if (hours <= 0)
        {
           
            PlayerPrefs.DeleteKey("endTime" + itemName);
            print(itemName + " is Expired!!");
            print("HOURS: " + hours);
        }

    }
}
