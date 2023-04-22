using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float sensitivity = 1.0f; // Sensitivity of mouse movement

    private float horizontalRotation = 0.0f; // Current horizontal rotation of the object

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Read the horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // Update the horizontal rotation of the object
        horizontalRotation += mouseX;

        // Apply the rotation to the object
        transform.localRotation = Quaternion.Euler(0.0f, horizontalRotation, 0.0f);
    }
}
