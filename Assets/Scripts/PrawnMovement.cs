using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrawnMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - transform.up * speed * Time.deltaTime;
        if (transform.position.y <= -9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && PlayerMovement.gotHit == false)
        {
            Destroy(gameObject);
        }
    }
}
