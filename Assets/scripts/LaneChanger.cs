using UnityEngine;
using System.Collections;

public class LaneChanger : MonoBehaviour {

	// Use this for initialization

    public string currentLane;
    GameObject player;
    SwipeMovement swipeScript;
    Camera cam;
    Animation anim;
	void Start () {
        cam = Camera.main;
        swipeScript = cam.GetComponent<SwipeMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider laneCollider)
    {
            
		if (laneCollider.tag == "character")
        {
            swipeScript.currentLane = currentLane;
            anim = laneCollider.gameObject.GetComponent<Animation>();
            if (laneCollider.name == "Ruth2") anim.CrossFade("shopper_idle_anim_root");
            else if (laneCollider.name == "Char") anim.CrossFade("gary_idle_anim");
            print("Lane Now: " + currentLane);
            swipeScript.setSwipeCap();
            swipeScript.swipeReload();
        }
    }

  /*  void OnTriggerExit(Collider laneCollider)
    {
        swipeScript.setSwipeCap();
    }*/
}
