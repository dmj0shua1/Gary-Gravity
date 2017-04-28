using UnityEngine;
using System.Collections;

public class RdmObjGen : MonoBehaviour {


    scoreCounter scoreCounterScript;
    GameObject objScoreCounter;
	public Transform[] SpawnPoints;
	public float spawnTimeObs,minSpawnTimeObs,maxSpawnTimeObs,spawnTimeCol,minSpawnTimeCol,maxSpawnTimeCol;
	//public GameObject Obstacles;
 	public GameObject[] Obstacles,Collectibles;
    public bool invokeCollectibles,stopBoostNow,stopShieldNow,stopAttackNow;
	// Use this for initialization

	void Start () {
        objScoreCounter = GameObject.Find("subScoreCounter");
        scoreCounterScript = objScoreCounter.GetComponent<scoreCounter>();
        invokeCollectibles = false ;

        if (PlayerPrefs.GetString("chosenChar") == "Shopper_girl")
        {
            Collectibles[0] = (GameObject)Resources.Load("Collectibles/Collectcard", typeof(GameObject));
            Collectibles[1] = (GameObject)Resources.Load("Collectibles/Collectbags", typeof(GameObject));
            Collectibles[3] = (GameObject)Resources.Load("Collectibles/Collectshoe", typeof(GameObject));
        }
        else if (PlayerPrefs.GetString("chosenChar") == "Fireman")
        {
            Collectibles[0] = (GameObject)Resources.Load("Collectibles/Collecthose", typeof(GameObject));
            Collectibles[1] = (GameObject)Resources.Load("Collectibles/Collectext", typeof(GameObject));
            Collectibles[3] = (GameObject)Resources.Load("Collectibles/Collectaxe", typeof(GameObject));
        }
	}

  /*  void checkNewSpeed()
    {
        if (gameObject.tag != "Foreground")
        {
            spawnTimeObs = scoreCounterScript.MoveSpeed ;
            spawnTimeCol = scoreCounterScript.MoveSpeed + 2.5f;
        }
    }*/
	// Update is called once per frame
	void Update () {
      //  checkNewSpeed();
        if (invokeCollectibles == true)
        {
            invokeCollectibles = false;
            InvokeRepeating("SpawnCollectibles", spawnTimeCol, spawnTimeCol);
       
        }
        InvokeRepeating("SpawnObstacles", spawnTimeObs, spawnTimeObs);

        if (stopBoostNow) Destroy(GameObject.FindGameObjectWithTag("CollectiblesBoost"));
        if (stopShieldNow) Destroy(GameObject.FindGameObjectWithTag("CollectiblesShield"));
        if (stopAttackNow) Destroy(GameObject.FindGameObjectWithTag("CollectiblesAttack"));
        }

	void SpawnObstacles() {
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		int obstaclesIndex = Random.Range (0, Obstacles.Length);
		Instantiate(Obstacles[obstaclesIndex], SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation);
       CancelInvoke("SpawnObstacles");
        spawnTimeObs = Random.Range(minSpawnTimeObs, maxSpawnTimeObs);
        
	}

    void SpawnCollectibles()
    { 
        int spawnIndex1 = Random.Range(0, SpawnPoints.Length);
        int obstaclesIndex1 = Random.Range(0, Collectibles.Length);

      

        Instantiate(Collectibles[obstaclesIndex1], SpawnPoints[spawnIndex1].position, SpawnPoints[spawnIndex1].rotation);
        CancelInvoke("SpawnCollectibles");
        invokeCollectibles = true;
        spawnTimeCol = Random.Range(minSpawnTimeCol, maxSpawnTimeCol);
      
    }
}
