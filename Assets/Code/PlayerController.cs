﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed=7f;

    private float moveInputx, moveInputy;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInputy = Input.GetAxisRaw("Vertical");
        moveInputx = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInputx*speed*Time.fixedDeltaTime,moveInputy*speed*Time.fixedDeltaTime);
    }
    
    
    
}
