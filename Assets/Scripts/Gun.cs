using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile bullet;
    

    public float fireRate = 0.2f; //ms
    public float projectileVelocity = 35f;
    private Transform[] objects;

    float nextShotTime;

    private void Awake() {
        objects = GetComponentsInChildren<Transform>();
    }

    public void Shoot() {
        if(Time.time > nextShotTime) {
            nextShotTime = Time.time + fireRate;
            Projectile newProjectile = Instantiate(bullet, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(projectileVelocity);
        }
    }

}
