using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFindWeaponState : AIState
{
    Animator aiAnimator;
    void AIState.Enter(AIAgent agent)
    {
        aiAnimator = agent.GetComponent<Animator>();
        WeaponPickup pickup = FindClosestWeapon(agent);
        aiAnimator.SetFloat("Speed", agent.navAgent.velocity.magnitude);
        agent.navAgent.destination = pickup.transform.position;
        agent.navAgent.speed = 5;

    }

    void AIState.Exit(AIAgent agent)
    {

    }

    AIStateID AIState.GetID()
    {
        return AIStateID.FindWeapon;
    }

    void AIState.Update(AIAgent agent)
    {
        aiAnimator.SetFloat("Speed", agent.navAgent.velocity.magnitude);
        if(agent.weapons.HasWeapon())
        {
            //agent.machine.ChangeState(AIStateID.AttackPlayer);
            agent.weapons.ActivateWeapon();
        }
    }
    private WeaponPickup FindClosestWeapon(AIAgent agent)
    {
        WeaponPickup[] weapons = Object.FindObjectsOfType<WeaponPickup>();
        WeaponPickup closestWeapon = null;
        float closestDistance = float.MaxValue;
        foreach(var weapon in weapons)
        {
            float distancetoWeapon = Vector3.Distance(agent.transform.position, weapon.transform.position);
            if(distancetoWeapon<closestDistance)
            {
                closestDistance = distancetoWeapon;
                closestWeapon = weapon;
            }
        }
        return closestWeapon;
    }
}
