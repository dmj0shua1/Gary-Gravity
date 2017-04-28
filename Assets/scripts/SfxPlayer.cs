using UnityEngine;
using System.Collections;

public class SfxPlayer : MonoBehaviour {
    public GameObject objSoundSource;
    private AudioSource asSfx;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playSfx()
    {
        asSfx = objSoundSource.GetComponent<AudioSource>();
        asSfx.Play();
    }
}
