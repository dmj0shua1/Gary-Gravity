using UnityEngine;
using System.Collections;

public class FgGen : MonoBehaviour {


	public Transform SpawnPoints;
	public float spawnTime = 1.5f;

	public GameObject bdForeground;
 	//public GameObject[] Obstacles;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnForeground", spawnTime,spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnForeground() {
		Instantiate(bdForeground, SpawnPoints.position, SpawnPoints.rotation);
	}
}
