using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb2d;
    public float movementSpeed;
    public float steeringPower = 5f;
    public float steeringAmount, speed, direction;

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
        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * movementSpeed;
        direction = Mathf.Sign(Vector2.Dot(rb2d.velocity, rb2d.GetRelativeVector(Vector2.up)));
        rb2d.rotation += steeringAmount * steeringPower * rb2d.velocity.magnitude * direction;

        rb2d.AddRelativeForce(Vector2.up * speed);

        rb2d.AddRelativeForce(-Vector2.right * rb2d.velocity.magnitude * steeringAmount / 2);
    }


    // Update is called once per frame
    void Update()
    {

    }
}