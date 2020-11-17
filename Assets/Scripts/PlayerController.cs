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
    public float steeringAmount, speed;
    public Transform direction;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
      

    }

    private void FixedUpdate()
    {
        direction.rotation = transform.rotation;
        Vector2 movement = new Vector2(movementVector.x, movementVector.y);
        rb2d.AddForce(movement * movementSpeed);
        if (movementVector.magnitude > 0.1f)
        {
            steeringAmount = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;
            rb2d.transform.rotation = Quaternion.Euler(new Vector3(0, 0, steeringAmount));
        }
        

    }


    // Update is called once per frame
    void Update()
    {

    }
}