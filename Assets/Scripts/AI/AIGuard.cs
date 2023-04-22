using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGuard : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        // Make decisions
        MakeDecisions();
    }

    protected override void MakeDecisions()
    {
        switch(currentState)
        {
            case AIStates.Guard:
                DoGuardState();
                // Check for transitions
                if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
            case AIStates.Chase:
                DoChaseState(target.transform.position);
                // Check for transitions
                if (IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIStates.Attack);
                }
                if (IsDistanceGreaterThan(target, 10))
                {
                    ChangeState(AIStates.Guard);
                }
                break;
            case AIStates.Attack:
                DoAttackState();
                // Check for transitions
                if (IsDistanceGreaterThan(target, 5))
                {
                    ChangeState(AIStates.Chase);
                }
                if (IsDistanceGreaterThan(target, 10))
                {
                    ChangeState(AIStates.Guard);
                }
                break;
            case AIStates.BackToPost:
                DoBackToPostState();
                break;
        }
    }
}