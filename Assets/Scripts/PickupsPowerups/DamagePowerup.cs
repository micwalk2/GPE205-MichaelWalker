<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamagePowerup : Powerup
{
    public float damageBonus;

    public override void ApplyPowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... add the speed bonus
            targetMover.fireForce += damageBonus;
        }
    }

    public override void RemovePowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... remove the speed bonus
            targetMover.fireForce -= damageBonus;
            Debug.Log(targetMover.name + " fireForce set to " + targetMover.fireForce);
        }
    }
}
=======
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamagePowerup : Powerup
{
    public float damageBonus;

    public override void ApplyPowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... add the speed bonus
            targetMover.fireForce += damageBonus;
        }
    }

    public override void RemovePowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... remove the speed bonus
            targetMover.fireForce -= damageBonus;
            Debug.Log(targetMover.name + " fireForce set to " + targetMover.fireForce);
        }
    }
}
>>>>>>> main
