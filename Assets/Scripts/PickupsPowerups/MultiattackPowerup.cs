<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiattackPowerup : Powerup
{
    public float attackSpeedBonus;

    public override void ApplyPowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... add the speed bonus
            targetMover.shotsPerSecond = targetMover.shotsPerSecond * attackSpeedBonus;
            Debug.Log(targetMover.name + " shots per second set to " + targetMover.shotsPerSecond);
        }
        else
        {
            Debug.Log("There is no Pawn component on " + target.name);
        }
    }

    public override void RemovePowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... remove the speed bonus
            targetMover.shotsPerSecond = targetMover.shotsPerSecond / attackSpeedBonus;
            Debug.Log(targetMover.name + " shots per second set to " + targetMover.shotsPerSecond);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultiattackPowerup : Powerup
{
    public float attackSpeedBonus;

    public override void ApplyPowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... add the speed bonus
            targetMover.shotsPerSecond = targetMover.shotsPerSecond * attackSpeedBonus;
            Debug.Log(targetMover.name + " shots per second set to " + targetMover.shotsPerSecond);
        }
        else
        {
            Debug.Log("There is no Pawn component on " + target.name);
        }
    }

    public override void RemovePowerup(PowerupManager target)
    {
        Pawn targetMover = target.GetComponent<Pawn>();

        // If targetMover is not null...
        if (targetMover != null)
        {
            // ... remove the speed bonus
            targetMover.shotsPerSecond = targetMover.shotsPerSecond / attackSpeedBonus;
            Debug.Log(targetMover.name + " shots per second set to " + targetMover.shotsPerSecond);
        }
    }
}
>>>>>>> main
