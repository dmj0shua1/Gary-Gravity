using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    public GameObject intro,loop;
    private AudioSource introMusic,loopMusic;
    private static MusicPlayer instance = null;
    public static MusicPlayer Instance
    {
        get { return instance; }
    }

    void Awake()
    {
         if (instance != null && instance != this) {
         Destroy(this.gameObject);
         return;
     } else {
         instance = this;
     }
     DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
       introMusic = intro.GetComponent<AudioSource>();
       loopMusic = loop.GetComponent<AudioSource>();
        if (!loopMusic.isPlaying)
        {
            introMusic.Play();
            loopMusic.PlayDelayed(12);
         
        }

	}
	
	// Update is called once per frame
	void Update () {
     
	}
   
}
