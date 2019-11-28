using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    private Animator animator;
    private Rigidbody2D rb;


    void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void FixedUpdate() {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if (rb.velocity.magnitude <= 0.5f) {
            rb.MovePosition(transform.position + new Vector3(horizontal, vertical, 0.0f).normalized * movementSpeed * Time.fixedDeltaTime);
        }
        // rb.AddForce(new Vector3(horizontal, vertical, 0.0f).normalized * movementSpeed, ForceMode2D.Force);
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(vertical + horizontal));
        
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
    }
}
