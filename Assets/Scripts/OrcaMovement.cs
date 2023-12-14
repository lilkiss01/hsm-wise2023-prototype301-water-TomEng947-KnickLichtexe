using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaMovement : MonoBehaviour
{
    private float t;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        speed = 1.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -12)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (transform.position.x >= 13)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        t += Time.deltaTime; 
        transform.position = transform.position - transform.right * speed * Time.deltaTime; 
    }
}
