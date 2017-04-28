using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spawnProjectile : MonoBehaviour {

	// Use this for initialization

    public GameObject spawnPointProjectile,character;
    public GameObject[] projectile;
    Button btnAttack;
    RdmObjGen rdmobj;
    cooldownAttack cooldownAttackScript;
    Animation playerAnim;
    int projIndex;

	void Start () {
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        spawnPointProjectile = GameObject.Find("spawnPointProjectile");
        btnAttack = gameObject.GetComponent<Button>();
        cooldownAttackScript = GameObject.Find("cooldownAttack").GetComponent<cooldownAttack>();

        

	}
	
	// Update is called once per frame
	void Update () {
     
	}

    public void fireProjectile()
    {
        character = GameObject.FindGameObjectWithTag("character");
        playerAnim = character.GetComponent<Animation>();

        if (PlayerPrefs.GetString("chosenChar") == "Shopper_girl") {
            playerAnim.Play("shopper_girl_attack");
            Invoke("replayFloat", 0.3f);
            projIndex = 0;
        }
        else if (PlayerPrefs.GetString("chosenChar") == "Fireman")
        {
            playerAnim.Play("gary_attack_anim");
            Invoke("replayFloat", 0.3f);
            projIndex = 1;
        }

        Instantiate(projectile[projIndex], spawnPointProjectile.transform.position, spawnPointProjectile.transform.rotation);
        btnAttack.interactable = false;
        cooldownAttackScript.decAttack();
    }

    void replayFloat()
    {
        if (PlayerPrefs.GetString("chosenChar") == "Shopper_girl") playerAnim.CrossFade("shopper_idle_anim_root");
        else if (PlayerPrefs.GetString("chosenChar") == "Fireman") playerAnim.CrossFade("gary_idle_anim");
        
    }

 
}
