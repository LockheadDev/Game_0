using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed=5f;

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
       
    }
    void FixedUpdate()
    {
        //Movement
        moveInputy = Input.GetAxisRaw("Vertical");
        moveInputx = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInputx*speed,moveInputy*speed);
        if (Input.GetKey(KeyCode.Comma))
        {
            
        }
        
    }
    
    
    
}
