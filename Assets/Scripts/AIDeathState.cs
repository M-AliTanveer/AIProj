using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    // Start is called before the first frame update
    void AIState.Enter(AIAgent agent)
    {
        agent.ragdoll.ActivateRagdoll(true);
        agent.healthBar.gameObject.SetActive(false);
        //agent.GetComponent<AIMovement>().enabled = false;
    }

    void AIState.Exit(AIAgent agent)
    {
    }

    AIStateID AIState.GetID()
    {
        return AIStateID.DeathState;
    }

    void AIState.Update(AIAgent agent)
    {
    }
}
