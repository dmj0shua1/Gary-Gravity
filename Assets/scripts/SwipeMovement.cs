using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class SwipeMovement : MonoBehaviour {

    public Slider healthBarSlider, boostbarSlider, shieldbarSlider, attackbarSlider;
	public string currentLane;
	public GameObject target1,target2,target3,protag,charMesh,smokeTrail,character;
	public Vector3 targetPosition,currentPosition;
    public float upSpeed, sideSpeed, angleLeft, angleRight, swipeCap, boostCap,shieldCap,attackCap;
    public static bool moveUp;
    SpriteRenderer tornadoSprite, tornadoSprite2;
    Animation anim;
    public float rotateQuat=90;
    public bool isGameOver;
    AudioSource asSfxSwipe;
    bool gameStarted;
    Animator foamLeft, foamRight;
    bool SwipeReady = true;
	// Use this for initialization
	void Start () {
        isGameOver = false;
        boostbarSlider.maxValue = boostCap;
        boostbarSlider.value = 0;
        shieldbarSlider.maxValue = shieldCap;
        shieldbarSlider.value = 0;
        attackbarSlider.maxValue = attackCap;
        attackbarSlider.value = 0;
        healthBarSlider.maxValue = swipeCap;
        healthBarSlider.value = swipeCap;
		currentLane = "Lane2";
		targetPosition = target2.transform.position;
        moveUp = true;

        Invoke("gameStartedOn",1.6f);

      

	}
	
	// Update is called once per frame
    void garySwipeDeclarations()
    {
        if (character.name == "Char")
        {
            foamLeft = GameObject.Find("gary_foamLeft").GetComponent<Animator>();
            foamRight = GameObject.Find("gary_foamRight").GetComponent<Animator>();
        }
    }

    public void swipeReload()
    {
        SwipeReady = true;
    }

	void FixedUpdate() {
        
        character = GameObject.FindGameObjectWithTag("character");
        anim = character.GetComponent<Animation>();
        protag = GameObject.FindGameObjectWithTag("Player");
        GameObject tornadoSide = GameObject.Find("bag tornado side moveLeft");
        GameObject tornadoSide2 = GameObject.Find("bag tornado side moveRight");

        if (character.name == "Ruth2")
        {
            tornadoSprite = tornadoSide.GetComponent<SpriteRenderer>();
            tornadoSprite2 = tornadoSide2.GetComponent<SpriteRenderer>();
        }
        else if (character.name == "Char")
        {
            garySwipeDeclarations();
        }
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && SwipeReady == true) {
			// Get movement of the finger since last frame
            SwipeReady = false;
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane

            if (touchDeltaPosition.x > 1 && swipeCap >= 1 && Time.timeScale == 1f && protag.GetComponent<Rigidbody>().velocity == Vector3.zero)
			{


               if (character.name=="Ruth2") anim["shopper_moveright_anim"].speed = 2.0f;
				//SwipeRight
                if (currentLane == "Lane2")
                {
                   targetPosition = target3.transform.position;
				}
                else if (currentLane == "Lane1")
                {
			        targetPosition = target2.transform.position;
				}

                if (character.name == "Ruth2")
                {
                    anim.Play("shopper_moveright_anim");
                    tornadoSprite2.enabled = true;
                    asSfxSwipe = GameObject.Find("sfxSwipeShopper_girl").GetComponent<AudioSource>();

                }
                else if (character.name == "Char")
                {
                    anim.Play("gary_swipe_right_anim");
                    asSfxSwipe = GameObject.Find("sfxSwipeFireman").GetComponent<AudioSource>();
                    foamRight.SetTrigger("isSwipedRight");

                }
                asSfxSwipe.Play();



            }
            else if (touchDeltaPosition.x < -1 && swipeCap >= 1 && Time.timeScale == 1f && protag.GetComponent<Rigidbody>().velocity == Vector3.zero)
			{
                if (character.name == "Ruth2") anim["shopper_moveleft_anim"].speed = 2.0f;
				//SwipeLeft
                    if (currentLane == "Lane2")
                    {
				    	targetPosition = target1.transform.position;
				    }
                    else if (currentLane == "Lane3")
                    {
					targetPosition = target2.transform.position;
				    }

                if (character.name == "Ruth2")
                {
                    anim.Play("shopper_moveleft_anim");
                    tornadoSprite.enabled = true;
                    asSfxSwipe = GameObject.Find("sfxSwipeShopper_girl").GetComponent<AudioSource>();

                }
                else if (character.name == "Char")
                {
                    anim.Play("gary_swipe_left_anim");
                    asSfxSwipe = GameObject.Find("sfxSwipeFireman").GetComponent<AudioSource>();
                    foamLeft.SetTrigger("isSwipedLeft");

                }
                asSfxSwipe.Play();
			}
            if (character.name == "Ruth2")  Invoke("disableTornadoSprite", 0.5f);
           
		}

   

       if (isGameOver == false ) MovePlayer();

	}

  

    void disableTornadoSprite(){
        tornadoSprite.enabled = false;
        tornadoSprite2.enabled = false;
    }
	private void MoveTowardsTarget() {
		//the speed, in units per second, we want to move towards the target

		//move towards the center of the world (or where ever you like)
		//targetPosition = maintarget.transform.position;

		currentPosition = protag.transform.position;
        
		//first, check to see if we're close enough to the target
		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize();
			//scale the movement on each axis by the directionOfTravel vector components

			
			protag.transform.Translate( 
				(directionOfTravel.x * sideSpeed * Time.deltaTime),
                (directionOfTravel.y * sideSpeed * Time.deltaTime),
                (directionOfTravel.z * sideSpeed * Time.deltaTime),
				Space.World);
		}
	}

    private void MovePlayer()
    {
        try
        {
            protag.transform.position = Vector3.Lerp(protag.transform.position, targetPosition, Time.deltaTime * upSpeed);
        }
        catch (Exception e)
        {
            //do nothing
        }
    }

    public void setSwipeCap()
    {
        if (gameStarted)
        {
            --swipeCap;
            healthBarSlider.value -= 1f;
        }
    }

    void gameStartedOn()
    {
        gameStarted = true;
    }
 

  
}
