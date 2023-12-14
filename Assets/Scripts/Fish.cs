using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Animator a_Animator;

    // Start is called before the first frame update
    void Start()
    {
        a_Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.gotHit == true)
        {
            a_Animator.SetBool("Death", true);
        }
    }
    
}

