<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        // Instantiate the projectile
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;

        // Get the DamageOnHit component
        DamageOnHit damageOnHit = newShell.GetComponent<DamageOnHit>();

        // If it has one...
        if (damageOnHit != null)
        {
            // ...set the damageDone in the DamageOnHit component to the value passed in
            damageOnHit.damageDone = damageDone;
            // ...set the owner to the pawn that shot the shell, if there is one (otherwise, owner is null)
            damageOnHit.owner = GetComponent<Pawn>();
        }

        // Get the rigidbody component
        Rigidbody rb = newShell.GetComponent<Rigidbody>();

        // If it has one...
        if (rb != null)
        {
            // ...AddForce to make it move forward
            rb.AddForce(firepointTransform.forward * fireForce);
        }

        // Destroy after a set time
        Destroy(newShell, lifespan);
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        // Instantiate the projectile
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;

        // Get the DamageOnHit component
        DamageOnHit damageOnHit = newShell.GetComponent<DamageOnHit>();

        // If it has one...
        if (damageOnHit != null)
        {
            // ...set the damageDone in the DamageOnHit component to the value passed in
            damageOnHit.damageDone = damageDone;
            // ...set the owner to the pawn that shot the shell, if there is one (otherwise, owner is null)
            damageOnHit.owner = GetComponent<Pawn>();
        }

        // Get the rigidbody component
        Rigidbody rb = newShell.GetComponent<Rigidbody>();

        // If it has one...
        if (rb != null)
        {
            // ...AddForce to make it move forward
            rb.AddForce(firepointTransform.forward * fireForce);
        }

        // Destroy after a set time
        Destroy(newShell, lifespan);
    }
}
>>>>>>> main
