using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : Pickup
{
    public DamagePowerup powerup;

    public override void OnTriggerEnter(Collider other)
    {
        // Variable to store other object's PowerupManager if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupManager...
        if (powerupManager != null)
        {
            // ... add the powerup
            powerupManager.Add(powerup);

            // ... and destroy this pickup
            Destroy(gameObject);
        }
        else
        {
            // ... otherwise, object doesn't have a PowerupManager
            Debug.Log(other.name + " has no PowerupManager!");
        }
    }
}
