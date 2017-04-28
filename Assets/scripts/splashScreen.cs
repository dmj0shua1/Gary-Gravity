using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("goToMenu", 1.3f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void goToMenu()
    {
        
        SceneManager.LoadScene("Menu");
       
    }

  
}
