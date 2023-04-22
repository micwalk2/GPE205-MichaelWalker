using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> removedPowerupQueue;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the list of powerups
        powerups = new List<Powerup>();
        removedPowerupQueue = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }

    private void LateUpdate()
    {
        ApplyRemovePowerupsQueue();
    }

    // The Add function will eventually add a powerup
    public void Add(Powerup powerupToAdd)
    {
        // Apply the powerup
        powerupToAdd.ApplyPowerup(this);
        // Save it to the list of powerups
        powerups.Add(powerupToAdd);
    }

    public void DecrementPowerupTimers()
    {
        // One-at-a-time, put each object in powerups into the variable powerup and do the loop body on it
        foreach (Powerup powerup in powerups)
        {
            // Subtract the time it took to draw the frame from the powerup's duration
            powerup.duration -= Time.deltaTime;

            // If the powerup's duration is less than or equal to zero and the powerup isn't permanent...
            if (powerup.duration <= 0)
            {
                // ... and isPermanent is false...
                if (!powerup.isPermanent)
                {
                    // ... remove the powerup
                    Remove(powerup);
                }
            }
        }
    }

    // The Remove function will eventually remove a powerup
    public void Remove(Powerup powerupToRemove)
    {
        // If powerupToRemove is not null...
        if (powerupToRemove != null)
        {
            // ... remove the powerup
            powerupToRemove.RemovePowerup(this);
            // ... and add it to the "to be removed" queue
            removedPowerupQueue.Add(powerupToRemove);
        }
    }

    private void ApplyRemovePowerupsQueue()
    {
        // If the "to be removed" queue is not null...
        if (removedPowerupQueue != null)
        {
            // ... remove all powerups in the "to be removed" queue
            foreach (Powerup powerup in removedPowerupQueue)
            {
                powerups.Remove(powerup);
            }
            // ...and reset our temporary list
            removedPowerupQueue.Clear();
        }
    }
}
