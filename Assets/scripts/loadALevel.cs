using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadALevel : MonoBehaviour {
    public string GoTo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void loadNow()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(GoTo);
    }
}
