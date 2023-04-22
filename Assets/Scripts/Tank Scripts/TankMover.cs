<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    // Variable for Rigidbody component
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    public override void Start()
    {
        // Get the Rigidbody component
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Move(Vector3 moveDirection, float speed)
    {
        Vector3 moveVector = moveDirection.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + moveVector);
    }

    public override void Rotate(float speed)
    {
        float rotateSpeed = speed * Time.deltaTime;
        rigidBody.transform.Rotate(0, rotateSpeed, 0);
    }
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    // Variable for Rigidbody component
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    public override void Start()
    {
        // Get the Rigidbody component
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void Move(Vector3 moveDirection, float speed)
    {
        Vector3 moveVector = moveDirection.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + moveVector);
    }

    public override void Rotate(float speed)
    {
        float rotateSpeed = speed * Time.deltaTime;
        rigidBody.transform.Rotate(0, rotateSpeed, 0);
    }
>>>>>>> main
}