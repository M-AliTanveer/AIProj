using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health health;
    // Start is called before the first frame update
    public  void onRayCastHit(RaycastWeapon weapon, Vector3 direction)
    {
        health.TakeDamage(weapon.damage,direction);
        Debug.Log("Hitbox: hit");
    }
}
