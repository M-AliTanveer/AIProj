using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFiring = false;
    [SerializeField] public Transform rayCastOrigin;
    Ray ray;
    public float damage = 10;
    RaycastHit hitInfo;
    [SerializeField] public Transform rayCastDestination;
    [SerializeField] TrailRenderer BulletEffect;
    [SerializeField] AIWeapons weapon;
    public void StartFiring()
    {
        isFiring = true;
        ray.origin = rayCastOrigin.position;
        ray.direction = rayCastDestination.position - rayCastOrigin.position;
        if(Physics.Raycast(ray,out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);
        }
        var tracer = Instantiate(BulletEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);
        tracer.transform.position = hitInfo.point;

        var hitBox = hitInfo.collider.GetComponent<HitBox>();
        Debug.Log("Before if");
        if(hitBox)
        {
            hitBox.onRayCastHit(this,ray.direction);
            Debug.Log("raycast: hitbox found " + hitBox.name);
        }
        isFiring = false;

    }

    // Update is called once per frame
    void StopFiring()
    {
        isFiring = false;
    }
}
