using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    // Start is called before the first frame update
    void AIState.Enter(AIAgent agent)
    {
    }

    void AIState.Exit(AIAgent agent)
    {
    }

    AIStateID AIState.GetID()
    {
        return AIStateID.Idle;
    }

    void AIState.Update(AIAgent agent)
    {
        Vector3 playerDirection = agent.player.transform.position - agent.transform.position;
        if (playerDirection.magnitude > agent.maxSight)
            return;

        Vector3 agetDirection = agent.transform.position;
        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agetDirection);
        if(dotProduct>0)
        {
            agent.machine.ChangeState(AIStateID.ChasePlayer);
        }
    }
}
