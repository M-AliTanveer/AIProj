using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] public float maxHealth;
    AIAgent agent;
    UIHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AIAgent>();
        agent.ragdoll = GetComponent<RagDoll>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<UIHealthBar>();


        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rigidBody in rigidBodies)
        {
            HitBox hitbox = rigidBody.gameObject.AddComponent<HitBox>();
            rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            hitbox.health = this;
        }
    }

    // Update is called once per frame
    public void TakeDamage(float amount,Vector3 direction)
    {
        currentHealth -= amount;
        healthBar.SetHealthBar(currentHealth / maxHealth);
        Debug.Log("Health: hit. " + amount.ToString());
        if (currentHealth<=0f)
        {
            Death();
        }
    }
    private void Death()
    {
        agent.machine.ChangeState(AIStateID.DeathState);
    }
}
