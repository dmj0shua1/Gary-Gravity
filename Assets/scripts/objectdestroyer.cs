using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class objectdestroyer : MonoBehaviour {

	// Use this for initialization
    public GameObject explosion,btnShieldObj;
    public Boolean isDestroyer = false;
    shieldToggle shieldToggleScript;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider obj)
    {

    
        if (isDestroyer && (obj.tag == "Foreground" || obj.tag == "Obstacles"))
        {
            Destroy(obj.gameObject);
        }
        else if(obj.tag == "Obstacles")
        {
            if (gameObject.name == "playerShield")
            {
                try
                { Instantiate(explosion, transform.position, transform.rotation); }
                catch (Exception e) { }
                btnShieldObj = GameObject.Find("btnShield");
                if (SceneManager.GetActiveScene().name == "Game") shieldToggleScript = btnShieldObj.GetComponent<shieldToggle>();
                shieldToggleScript.deactivateShield();
                Destroy(obj.gameObject);
                GameObject objSfxDestByShield = GameObject.Find("sfxDestroyedByShield");
                AudioSource asSfxDestByShield = objSfxDestByShield.GetComponent<AudioSource>();
                asSfxDestByShield.Play();
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                BoxCollider colPlayer = player.GetComponent<BoxCollider>();
              
             
            }
            else if (gameObject.tag == "PowerAttack")
            {
                GameObject objSfxDestByAttack = GameObject.Find("sfxDestroyedByAttack");
                AudioSource asSfxDestByAttack = objSfxDestByAttack.GetComponent<AudioSource>();
                asSfxDestByAttack.Play();
              
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);

                Invoke("destroyExp", 0.5f);
                Destroy(gameObject);
                Destroy(obj.gameObject);
            }

           
        }
    }

    void destroyExp()
    {
        Destroy(explosion);
    }
}
