using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksDispatcher : MonoBehaviour
{

    public float speed = -5.0f;

    public float minSpawnSeconds = 1.0f;
    public float maxSpawnSeconds = 5.0f;

    public Vector3 spawnLocation;

    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = GetComponent<ObjectPooler>();
        spawnLocation = transform.position;
        StartCoroutine(SpawnRock());
    }

    IEnumerator SpawnRock() {
        while (true)
        {
            GameObject rock = (GameObject) objectPooler.GetInstance();
            if (rock != null) {
                rock.transform.position = spawnLocation;
                Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(speed, 0);
            }
            yield return new WaitForSeconds(Random.Range(minSpawnSeconds, maxSpawnSeconds));
        }
    }

    

    void Update()
    {
        
    }
}
