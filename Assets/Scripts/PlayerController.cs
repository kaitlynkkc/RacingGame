using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb2d;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>()*movementSpeed;



    }

    private void FixedUpdate()
    {
        rb2d.velocity = movementVector;
    }


    // Update is called once per frame
    void Update()
    {

    }
}