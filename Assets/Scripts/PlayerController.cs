using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb2d;

    public float movementSpeed;
    public float steeringAmount;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        steeringAmount = this.transform.rotation.z;
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
      

    }

    private void FixedUpdate()
    {
        //Vector2 movement = new Vector2(0.0f,);
       // rb2d.AddForce(movement * movementSpeed);
       if(movementVector.y > 0.0f)
        {
            rb2d.AddForce(new Vector2(0, movementVector.y));
        }
        if (movementVector.x < 0.0f)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, steeringAmount++));
        }
        else if (movementVector.x > 0.0f)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, steeringAmount--));
        }
        

    }


    // Update is called once per frame
    void Update()
    {

    }
}