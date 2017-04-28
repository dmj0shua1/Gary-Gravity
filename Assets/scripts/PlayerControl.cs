using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameObject player;
	public Transform Lane1,Lane2,Lane3;
	public string currentLane="Lane2";
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		checkLane ();

	}

	void checkLane(){
		if (currentLane == "Lane2") {
			if (Input.GetKeyDown ("d")) {
				currentLane = "Lane3";
				player.transform.position = Vector3.MoveTowards (player.transform.position, Lane3.position, 1);
			}
			if (Input.GetKeyDown ("a")) {
				currentLane = "Lane1";
				player.transform.position = Vector3.MoveTowards (player.transform.position, Lane1.position, 1);
			}
		}
		if (currentLane == "Lane1") {
			if (Input.GetKeyDown ("d")) {
				currentLane = "Lane2";
				player.transform.position = Vector3.MoveTowards (player.transform.position, Lane2.position, 1);
			}
		}
		if (currentLane == "Lane3") {
			if (Input.GetKeyDown ("a")) {
				currentLane = "Lane2";
				player.transform.position = Vector3.MoveTowards (player.transform.position, Lane2.position, 1);
			}
		}
	}
}
