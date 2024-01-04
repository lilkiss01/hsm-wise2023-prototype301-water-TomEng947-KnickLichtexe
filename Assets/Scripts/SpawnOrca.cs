using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrca : MonoBehaviour
{
    private float t, height;
    public GameObject enemyObject;
    public float spawnTime, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (t >= spawnTime && UiStuff.isStarted)
        {
            height = Random.Range(-maxHeight, maxHeight);
            Spawn1Orca();
            t = 2f;
        }
    }

    private void Spawn1Orca()
    {
        GameObject gameObject1 = Instantiate(enemyObject, transform.position + new Vector3(12.9f, height, -3f), transform.rotation);
    }
}