using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float t, speed, whatever;
    public int spin, score, timer;
    public static bool gotHit;

    public string textMessagesValue;
    public Text textMessages;
    public string textInstructionValue;
    public Text textInstruction;
    public string textScoreValue;
    public Text textScore;
    public string textTimeValue;
    public Text textTime;

    // Start is called before the first frame update
    void Start()
    {
        gotHit = false;
        speed = 2f;
        spin = 0;
        score = 0;
        t = 0;
        timer = 0;
        textTime.text = "60";
        textScore.text = "Score:  0";
    }

    // Update is called once per frame
    void Update()
    {
       
        if (UiStuff.isStarted)
        {
            if (!gotHit)
            {

                transform.position = transform.position + transform.right * speed * Time.deltaTime;

                if (Input.GetKeyUp("space"))
                {
                    spin += 90;
                    transform.rotation = Quaternion.Euler(0, 0, spin);
                }

                if (Input.GetKey("space"))
                {
                    transform.position = transform.position + transform.right * speed * Time.deltaTime;
                }

                t += Time.deltaTime;

                if (t >= timer && t <= 60)
                {
                    timer++;
                    textTime.text = (60 - timer).ToString();
                }

                if (t > 60)
                {
                    textMessages.text = textMessagesValue;
                    textInstruction.text = textInstructionValue;
                    gotHit = true;
                }

                if (gameObject.transform.position.x > 10)
                {
                    transform.position +=  new Vector3(-20, 0, 0) ;
                }
                if (gameObject.transform.position.x < -10)
                {
                    transform.position += new Vector3(20, 0, 0);
                }
                if (gameObject.transform.position.y > 6.5f)
                {
                    transform.position += new Vector3(0, -11.5f, 0);
                }
                if (gameObject.transform.position.y < -5)
                {
                    transform.position += new Vector3(0, 11.5f, 0);
                }
            }
        }

        if (Input.GetKeyDown("r"))
        {
            UiStuff.isStarted = false;
            SceneManager.LoadScene("PECECITO_A_COMER");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gotHit == false)
        {
            if (other.gameObject.tag == "Food")
            {
                score++;
                textScore.text = "Score:  " + score.ToString();

            }

            if (other.gameObject.tag == "SpecialFood")
            {
                score += 10;
                textScore.text = "Score:  " + score.ToString();

            }
        }

            if (other.gameObject.tag == "Enemy")
            {
                textMessages.text = textMessagesValue;
                textInstruction.text = textInstructionValue;
                gotHit = true;
            }
        
    }
}
