using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    private Vector2 direction;
    private float speed = 10;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        GetInput();
    }  

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = moveInput.normalized * speed;
    }

    private void Move()
    {
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
    }
}
