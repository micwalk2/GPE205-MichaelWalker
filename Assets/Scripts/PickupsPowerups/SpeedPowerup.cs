<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerup : Powerup
{
    public float speedBonus;

    public override void ApplyPowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... add the speed bonus
            targetMover.moveSpeed += speedBonus;
        }
    }

    public override void RemovePowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... remove the speed bonus
            targetMover.moveSpeed -= speedBonus;
            Debug.Log(targetMover.name + " moveSpeed set to " + targetMover.moveSpeed);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerup : Powerup
{
    public float speedBonus;

    public override void ApplyPowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... add the speed bonus
            targetMover.moveSpeed += speedBonus;
        }
    }

    public override void RemovePowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... remove the speed bonus
            targetMover.moveSpeed -= speedBonus;
            Debug.Log(targetMover.name + " moveSpeed set to " + targetMover.moveSpeed);
        }
    }
}
>>>>>>> main
