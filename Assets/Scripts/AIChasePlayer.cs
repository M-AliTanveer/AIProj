using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIChasePlayer : AIState
{
    
    Animator aiAnimator;
    
    // Start is called before the first frame update
    public void Enter(AIAgent agent)
    {
        aiAnimator = agent.GetComponent<Animator>();
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID GetID()
    {
        return AIStateID.ChasePlayer;
    }

    public void Update(AIAgent agent)
    {
        agent.navAgent.destination = agent.player.position;
        aiAnimator.SetFloat("Speed", agent.navAgent.velocity.magnitude);
        if (!agent.navAgent.hasPath)
            agent.navAgent.destination = agent.player.position;
    }
}
