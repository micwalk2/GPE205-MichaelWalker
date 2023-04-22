using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Powerup
{
    public float duration;
    public bool isPermanent;

    public abstract void ApplyPowerup(PowerupManager target);
    public abstract void RemovePowerup(PowerupManager target);
}
