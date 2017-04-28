using UnityEngine;
using System.Collections;

public class camdescend : MonoBehaviour
{
    scoreCounter scoreCounterScript;
    GameObject objScoreCounter;
    public float MoveSpeed = 1f;

    void Start()
    {
        objScoreCounter = GameObject.Find("subScoreCounter"); try
        {

            scoreCounterScript = objScoreCounter.GetComponent<scoreCounter>();
        }
        catch (System.Exception)
        {
            
          
        }
    }
    void Update()
    {
        transform.Translate((Vector3.down * (Time.deltaTime * MoveSpeed)), Space.World);
        checkNewSpeed();

    }

    void checkNewSpeed()
    {
        if (gameObject.tag != "Foreground")
        {
            try
            {
                MoveSpeed = scoreCounterScript.MoveSpeed;
            }
            catch (System.Exception)
            {
                
               
            }
        }
    }

}
