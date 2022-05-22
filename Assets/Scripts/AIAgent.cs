using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    [SerializeField] public Transform player;
    public AIStateMachine machine;
    public AIStateID initital;
    public NavMeshAgent navAgent;
    public RagDoll ragdoll;
    public UIHealthBar healthBar;
    public float maxSight = 5f;
    [SerializeField] public AIWeapons weapons;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        weapons = GetComponent<AIWeapons>();
        navAgent = GetComponent<NavMeshAgent>();
        ragdoll = GetComponent<RagDoll>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        machine = new AIStateMachine(this);
        machine.RegisterState(new AIChasePlayer());
        machine.RegisterState(new AIDeathState());
        machine.RegisterState(new AIIdleState());
        machine.RegisterState(new AIFindWeaponState());
        machine.RegisterState(new AIAttackPlayer());
        machine.ChangeState(initital);
    }

    // Update is called once per frame
    void Update()
    {
        machine.Update();
    }
}
