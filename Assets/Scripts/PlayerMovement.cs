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

    public GameObject Restart;
    public GameObject DeadParticle;
    public GameObject FishParticle;
    public GameObject OrcaSpawner;
    public AudioSource Aud_Crunch;
    public AudioSource Aud_Music;
    public ParticleSystem foodParticleEffect;
    public ParticleSystem DeadParticleEffect;

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
                    Restart.SetActive(true);
                    OrcaSpawner.SetActive(false);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gotHit == false)
        {
            if (other.gameObject.tag == "Food")
            {
                score++;
                textScore.text = "Score:  " + score.ToString();
                Aud_Crunch.Play();
                PlayParticleEffect(foodParticleEffect);
                FishParticle.SetActive(true);
            }

            if (other.gameObject.tag == "SpecialFood")
            {
                score += 10;
                textScore.text = "Score:  " + score.ToString();
                Aud_Crunch.Play();
                PlayParticleEffect(foodParticleEffect);
                FishParticle.SetActive(true);
            }
        }

            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("Player got hit!");
                Restart.SetActive(true);
                textMessages.text = textMessagesValue;
                textInstruction.text = textInstructionValue;
                gotHit = true; 
                PlayParticleEffect(DeadParticleEffect);
                DeadParticle.SetActive(true);
                OrcaSpawner.SetActive(false);
                Aud_Music.Stop();
            }
        
    }

    private void PlayParticleEffect(ParticleSystem particleEffect)
    {
        if (particleEffect != null)
        {
            particleEffect.Play();
        }
    }
}
