using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Private variables
    private float shotCooldown;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        shotCooldown = Time.time;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    // Movement functions below check whether object mover is null and if not, execute the Move() function to move the tank.
    // Otherwise, will throw a warning stating there is no Mover.
    public override void MoveForward()
    {
        if (mover != null)
        {
            mover.Move(transform.forward, moveSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveForward()!");
        }
    }
    public override void MoveBackward()
    {
        if (mover != null)
        {
            mover.Move(transform.forward, -moveSpeed);
        } 
        else
        {
            Debug.LogWarning("Warrning: No Mover in TankPawn.MoveForward()!");
        }
    }
    public override void RotateClockwise()
    {
        if (mover != null)
        {
            mover.Rotate(turnSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveForward()!");
        }
    }
    public override void RotateCounterClockwise()
    {
        if (mover != null)
        {
            mover.Rotate(-turnSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveForward()!");
        }
    }
    public override void RotateTowards(Vector3 targetPosition)
    {
        // Find the vector to our target
        Vector3 vectorToTarget = targetPosition - transform.position;
        // Find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        // Rotate closer to that vector, but don't rotate more than our turn speed allows in one frame
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
    public override void RotateAway(Vector3 targetPosition)
    {
        // Find the vector to our target
        Vector3 vectorToTarget = targetPosition - transform.position;
        // Declare the flee vector
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        // Normalize and multiply by flee distance
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
    }

    public override void Shoot()
    {
        if (Time.time >= shotCooldown)
        {
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifeSpan);
            shotCooldown = Time.time + secondsPerShot;
        }
    }
}