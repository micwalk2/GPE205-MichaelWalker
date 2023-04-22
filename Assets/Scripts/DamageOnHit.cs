using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    // Public variables
    public float damageDone;
    public Pawn owner;

    // Execute when called as an event trigger
    public void OnTriggerEnter(Collider other)
    {
        // Get the Health component from the object that has the collider we are overlapping
        Health otherHealth = other.GetComponent<Health>();
        // Only damage if it has a Health component
        if (otherHealth != null )
        {
            // Do damage
            otherHealth.TakeDamage(damageDone, owner);
        }

        // Destroy ourselves, whether we did damage or not
        Destroy(gameObject);
    }
}
