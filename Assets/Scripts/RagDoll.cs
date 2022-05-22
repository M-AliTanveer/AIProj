using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody[] rigidBodies;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var body in rigidBodies)
            body.detectCollisions = true;
    }


    // Update is called once per frame
    public void ActivateRagdoll(bool flag)
    {
        foreach (var body in rigidBodies)
        {
            body.isKinematic = !flag;
            if (flag)
                animator.enabled = !flag;

        }
    }


}