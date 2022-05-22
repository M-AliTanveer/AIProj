using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackPlayer : AIState
{
    void AIState.Enter(AIAgent agent)
    {
        agent.weapons.ActivateWeapon();
        agent.weapons.setTarget(agent.player);
        agent.navAgent.destination = agent.player.position;
    }

    void AIState.Exit(AIAgent agent)
    {
    }

    AIStateID AIState.GetID()
    {
        return AIStateID.AttackPlayer;
    }

    void AIState.Update(AIAgent agent)
    {
    }

    
}
