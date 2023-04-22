using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Public variables
    public float currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Set health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float amount, Pawn source)
    {
        // Check to see if amount to be healed will bring us over maxHealth
        if (currentHealth + amount >= maxHealth)
        {
            // ...set currentHealth to maxHealth
            currentHealth = maxHealth;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            Debug.Log(source.name + " healed to full health!");
        }
        else
        {
            // ...otherwise, apply the amount to be healed to currentHealth
            currentHealth += amount;
            Debug.Log(source.name + " healed for " + amount + "!");
        }
    }

    public void TakeDamage(float amount, Pawn source)
    {
        // Subtract the damage dealt from currentHealth and clamp it
        currentHealth = currentHealth - amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        // Check to see if gameObject is null
        if (gameObject != null)
        {
            // Log the result
            Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
        }

        // Check whether damage dealt was enough to kill
        if (currentHealth <= 0)
        {
            Die(source);
        }
    }

    public void Die(Pawn source)
    {
        Destroy(gameObject);
    }
}
