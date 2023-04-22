using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Public variables
    public float shotsPerSecond;
    public float moveSpeed;
    public float turnSpeed;
    public float fleeDistance;

    // Variable for shell prefab
    public GameObject shellPrefab;
    // Variable for our firing force
    public float fireForce;
    // Variable for damage done
    public float damageDone;
    // Variable for how long our bullet survives if there is no collision
    public float shellLifeSpan;

    public Mover mover;
    public Shooter shooter;

    // Private variables
    protected float secondsPerShot;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Get the mover and shooter components
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();

        // Calculate the seconds per shot
        secondsPerShot = 1 / shotsPerSecond;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    // Function declarations for tank movement control
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);
    public abstract void RotateAway(Vector3 targetPosition);
}
