using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;

    // Start is called before the first frame update
    public override void Start()
    {
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // Tracks the players
            if (GameManager.instance.players != null)
            {
                // Register with GameManager
                GameManager.instance.players.Add(this);
            }
        }

        // Run the Start() function from the parent class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Process keyboard inputs
        ProcessInputs();

        // Run the Update() function from the parent class
        base.Update();
    }

    public void OnDestroy()
    {
        // If we have a GameManager...
        if (GameManager.instance != null)
        {
            // ...and it tracks the player(s)
            if (GameManager.instance.players != null)
            {
                // ...deregister with GameManager
                GameManager.instance.players.Remove(this);
            }
        }
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }

        if (Input.GetKey(shootKey))
        {
            pawn.Shoot();
        }
    }
}
