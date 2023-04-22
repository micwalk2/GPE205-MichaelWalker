using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    // List of possible states
    public enum AIStates
    {
        ChooseTarget,
        Guard,
        Chase,
        Flee,
        Patrol,
        Attack,
        Scan,
        Alert,
        BackToPost
    };
    // Current state
    public AIStates currentState;
    // Time when we last changed states
    private float lastStateChangeTime;

    // Target to chase
    public GameObject target;

    // Waypoint information
    public bool isLoopable;
    public Transform[] waypoints;
    public float waypointStopDistance;
    private int currentWaypoint = 0;

    // Listener information
    public float hearingDistance;

    // Start is called before the first frame update
    public override void Start()
    {
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // Tracks the players
            if (GameManager.instance.aiPlayers != null)
            {
                // Register with GameManager
                GameManager.instance.aiPlayers.Add(this);
            }
        }

        ChangeState(AIStates.Guard);

        // Run the parent (base) Start
        base.Start();
    }
    // Update is called once per frame
    public override void Update()
    {
        // Make decisions
        MakeDecisions();
        // Run the parent (base) update
        base.Update();
    }
    public void OnDestroy()
    {
        // If we have a GameManager...
        if (GameManager.instance != null)
        {
            // ...and it tracks the player(s)
            if (GameManager.instance.aiPlayers != null)
            {
                // ...deregister with GameManager
                GameManager.instance.aiPlayers.Remove(this);
            }
        }
    }

    //--------------------------------------------------------------------------------
    // This is where the methods will be for the different states
    //--------------------------------------------------------------------------------
    // Make decisions based on the current state
    protected virtual void MakeDecisions()
    {

    }
    // Change the current state
    protected void ChangeState(AIStates newState)
    {
        // Change the current state
        currentState = newState;
        // Save the time when we changed states
        lastStateChangeTime = Time.time;
    }
    protected void DoGuardState()
    {
        // Print to the debug log
        // Debug.Log("DoGuardState");
    }
    protected void DoChaseState(Vector3 targetPosition)
    {
        // Chase our target
        Chase(target);
    }
    protected void Chase(Vector3 targetPosition)
    {
        // Rotate towards the target
        pawn.RotateTowards(target.transform.position);
        // Move forward
        pawn.MoveForward();
    }
    protected void Chase(Transform targetTransform)
    {
        // Seek the position of our target transform
        Chase(targetTransform.position);
    }
    protected void Chase(GameObject target)
    {
        // Seek the pawn's transform
        Chase(target.transform);
    }
    protected void DoFleeState()
    {
        // Flee from target
        Flee(target);
    }
    protected void Flee(GameObject target)
    {
        // Get the vector to the target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        // Get the vector away from the target
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        // Get the distance to the target
        float targetDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
        // Get the percentage of the flee distance
        float percentOfFleeDistance = targetDistance / pawn.fleeDistance;
        // Clamp the percentage
        percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
        // Flip the percentage
        float flippedPercentOfFleeDistance = 1 - percentOfFleeDistance;
        Vector3 fleeVector = vectorAwayFromTarget.normalized * pawn.fleeDistance;

        // Check if targetDistance is at least one unit away
        if (targetDistance <= 1.0f)
        {
            // Rotate away from the target
            pawn.RotateAway(target.transform.position);
            // Move forward
            pawn.MoveForward();
        }
        else
        {
            // Change to Guard state
            ChangeState(AIStates.Guard);
        }
    }
    protected void DoPatrolState()
    {
        // Print to the debug log
        // Debug.Log("DoPatrolState");
    }
    protected void Patrol()
    {
        // If we have enough waypoints in our list to move to a current waypoint
        if (waypoints.Length > currentWaypoint)
        {
            // Then seek the waypoint
            Chase(waypoints[currentWaypoint]);
            // If we are close enough, then increment to the next waypoint
            if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
            // Check to see if the patrol is loopable
            if (isLoopable)
            {
                RestartPatrol();
            }
        }
    }
    protected void RestartPatrol()
    {
        // Set the index to 0
        currentWaypoint = 0;
    }
    protected void DoAttackState()
    {
        // Print to the debug log
        Debug.Log("DoAttackState");

        // Check to see if target is not null
        if (target != null)
        {
            float targetHealth = target.GetComponent<Health>().currentHealth;

            // Check if target is dead
            if (targetHealth <= 0)
            {
                // Change state to back to post
                ChangeState(AIStates.Guard);
            }
            else
            {
                pawn.Shoot();
            }
        }
    }
    protected void DoScanState()
    {
        // Print to the debug log
        // Debug.Log("DoScanState");
    }
    protected void DoAlertState()
    {
        // Print to the debug log
        // Debug.Log("DoAlertState");
    }
    protected void DoBackToPostState()
    {
        // Print to the debug log
        // Debug.Log("DoBackToPostState");
    }

    // Target player one
    public void TargetPlayerOne()
    {
        // If the GameManager exists...
        if (GameManager.instance != null)
        {
            // ...and the array of players exists...
            if (GameManager.instance.players != null)
            {
                // ... and there are players in it...
                if (GameManager.instance.players.Count > 0)
                {
                    // ...then target the gameObject of the pawn of the first player controller in the list
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }
    // Check to see if target is already set
    protected bool IsHasTarget()
    {
        // Return true if we have a target, false if we don't
        return (target != null);
    }

    //--------------------------------------------------------------------------------
    // Utility functions
    //--------------------------------------------------------------------------------
    // Check to see if distance to target is less than distance
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Check to see if distance to target is greater than distance
    protected bool IsDistanceGreaterThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) > distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanHear(GameObject target)
    {
        // Get the NoiseMaker component from the target
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // If there is no NoiseMaker component, return false
        if (noiseMaker == null)
        {
            return false;
        }
        // If they are making 0 noise, they cannot be heard
        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }
        // If they are making noise, add the volumeDistance to the hearing Distance
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        // If the distance between the target and this pawn is less than the total distance, return true
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            return true;
        }
        else
        {
            // Otherwise, we are too far away to be heard
            return false;
        }
    }
}
