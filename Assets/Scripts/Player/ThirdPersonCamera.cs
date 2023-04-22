<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // the target object to follow
    public float distance = 5.0f;  // distance from the target
    public float height = 2.0f;  // height of the camera above the target
    public float damping = 5.0f;  // smoothing factor for camera movement
    public bool rotateWithTarget = true; // whether to rotate the camera with the target

    private Vector3 offset;  // offset from the target

    void Start()
    {
        // Calculate the initial offset from the target
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera based on the object's forward direction
            Vector3 desiredPosition = target.position - target.forward * distance;
            desiredPosition.y = target.position.y + height;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

            // Optionally rotate the camera with the target
            if (rotateWithTarget)
            {
                transform.LookAt(target);
            }
        }
        else
        {
            Debug.Log("Warning! Target object has been destroyed");
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // the target object to follow
    public float distance = 5.0f;  // distance from the target
    public float height = 2.0f;  // height of the camera above the target
    public float damping = 5.0f;  // smoothing factor for camera movement
    public bool rotateWithTarget = true; // whether to rotate the camera with the target

    private Vector3 offset;  // offset from the target

    void Start()
    {
        // Calculate the initial offset from the target
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera based on the object's forward direction
            Vector3 desiredPosition = target.position - target.forward * distance;
            desiredPosition.y = target.position.y + height;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

            // Optionally rotate the camera with the target
            if (rotateWithTarget)
            {
                transform.LookAt(target);
            }
        }
        else
        {
            Debug.Log("Warning! Target object has been destroyed");
        }
    }
}
>>>>>>> main
