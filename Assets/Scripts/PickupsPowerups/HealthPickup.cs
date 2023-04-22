using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    // The powerup variable will eventually hold a reference to the powerup
    public HealthPowerup powerup;

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
            Debug.Log(gameObject);
        }
        else
        {
            // ... otherwise, object doesn't have a PowerupManager
            Debug.Log(other.name + " has no PowerupManager!");
        }
    }
}
