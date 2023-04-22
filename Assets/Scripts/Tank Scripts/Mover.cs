using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public abstract void Start();

    // Handles the movement of any Mover
    public abstract void Move(Vector3 moveDirection, float speed);
    public abstract void Rotate(float speed);
}