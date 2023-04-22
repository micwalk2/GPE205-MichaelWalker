using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class HealthPowerup : Powerup
{
    public float healthToAdd;

    public override void ApplyPowerup(PowerupManager target)
    {
        // Apply the health changes
        Health targetHealth = target.GetComponent<Health>();

        if(targetHealth != null)
        {
            // Second parameter is the pawn who caused the healing - in this case, they healed themselves
            targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
        }
        Debug.Log("Added " + healthToAdd + " health to " + target.gameObject.name);
    }

    public override void RemovePowerup(PowerupManager target)
    {
        // Remove health changes
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(healthToAdd, target.GetComponent<Pawn>());
        }
        Debug.Log("Removed " + healthToAdd + " health from " + target.gameObject.name);
    }
}
