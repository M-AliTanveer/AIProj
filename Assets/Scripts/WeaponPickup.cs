using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public RaycastWeapon weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
            return;
        RaycastWeapon avail_weapon = other.gameObject.GetComponent<RaycastWeapon>();
        if(avail_weapon)
        {
            RaycastWeapon newWeapon = Instantiate(weapon);
        }
        HitBox hitBox = other.gameObject.GetComponent<HitBox>();
        if (hitBox)
        {
            Debug.Log("inside iff " + hitBox.ToString());
            AIWeapons weapons = hitBox.health.GetComponent<AIWeapons>();
            if (weapons != null)
            {
                Debug.Log("WEapons");
                RaycastWeapon newWeapon = Instantiate(weapon);
                weapons.currentWeapon = newWeapon;
                weapons.EquipWeapon();
                Destroy(gameObject);
            }
        }
    }
}
