using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksDispatcher : MonoBehaviour
{

    public float speed = -5.0f;

    public float minSpawnSeconds = 1.0f;
    public float maxSpawnSeconds = 5.0f;

    public GameObject objectToSpawn;

    public Vector3 spawnLocation;

    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = new ObjectPooler(10, objectToSpawn);
        SpawnRock();
    }

    IEnumerable SpawnRock() {
        GameObject rock = (GameObject) objectPooler.GetInstance();
        rock.transform.position = spawnLocation;
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        yield return new WaitForSeconds(2.0f);
        SpawnRock();
    }

    void Update()
    {
        
    }
}
