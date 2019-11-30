using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public Camera cam = null;
    private float width = 0.0f;
    private Vector2 startPosition;

    void Awake() {
        if (cam == null) {
            cam = Camera.main;
        }

        startPosition = new Vector2(transform.position.x, transform.position.y);

        Vector3 size = GetComponent<SpriteRenderer>().bounds.size;
        width = size.x;
    }

    void Start()
    {
    }

    void Update()
    {
        float distance = cam.transform.position.x - transform.position.x;

        if (width < distance)
        {
            transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
        }
        else if (width < -distance) {
            transform.position = new Vector3(transform.position.x - width, transform.position.y, transform.position.z);
        }
    }
}
