using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMouse : MonoBehaviour
{
    [SerializeField] 
    private Transform ShipPlace;

    private Vector2 initialPosition;
    private Vector2 mousePosition;


    private float deltaX, deltaY;
    private Rigidbody2D rb;

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }
    private void OnMouseUp()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
}
