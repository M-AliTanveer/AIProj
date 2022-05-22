using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapons : MonoBehaviour
{
    public RaycastWeapon currentWeapon;
    Animator aiAnimator;
    WeaponIK weaponIK;
    Transform currentTarget;

    private void Start()
    {
        aiAnimator = GetComponent<Animator>();
        weaponIK = GetComponent<WeaponIK>();
    }
    public void EquipWeapon()
    {
        aiAnimator.SetBool("Equipped", true);
        currentWeapon.transform.SetParent(transform, false);
        Transform gunPos = GameObject.FindGameObjectWithTag("GunLocation").transform;
        currentWeapon.transform.position = gunPos.position;
        currentWeapon.transform.eulerAngles = gunPos.eulerAngles;

        weaponIK.SetAimTransform(currentWeapon.rayCastOrigin);
    }

    public void ActivateWeapon()
    {

        EquipWeapon();

    }

    public void setTarget(Transform target)
    {
        weaponIK.SetTargetTransform(target);
        currentTarget = target;
    }

    public bool HasWeapon()
    {
        return currentWeapon != null;
    }
}
