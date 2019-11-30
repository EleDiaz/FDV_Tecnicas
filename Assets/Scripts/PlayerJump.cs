using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    public float jumpForce = 10.0f;
    private Rigidbody2D rb;

    public GameObject groundObject;

    private bool _isJumping = false;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {

    }

    void FixedUpdate () {
        if (Input.GetButtonDown ("Jump") && !_isJumping) {
            _isJumping = true;
            rb.AddForce (new Vector2 (0, jumpForce));
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == groundObject && rb.velocity.magnitude < 0.1) {
            _isJumping = false;
        }
    }
}