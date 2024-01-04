using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiStuff : MonoBehaviour
{
    private GameObject startScreen;
    private Vector3 targetSize, startSize;
    public static bool isStarted;
    public GameObject Aud;

    // Start is called before the first frame update
    void Start()
    {
        startScreen = GameObject.Find("StartScreen");
        targetSize = startScreen.transform.localScale * 7;
        startSize = startScreen.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        { 
            isStarted = true;
        }

        if (PlayerMovement.gotHit)
        {

            float t = 0f;
            t += Time.deltaTime;
            startScreen.SetActive(true);
           
        }

        else if (isStarted)
        {

            float t = 0f;
            t += Time.deltaTime;
            if (t < 0.95f)
            {
                Aud.SetActive(true);
                startScreen.transform.localScale = Vector3.Lerp(startScreen.transform.localScale, targetSize, t * 2f);
            }
            else
            {
                startScreen.SetActive(false);
            }


        }



    }
}