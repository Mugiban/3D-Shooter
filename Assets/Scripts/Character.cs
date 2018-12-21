using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable {

    public float startingHealth = 100f;
    protected float health;
    protected bool dead = false;

    public event System.Action OnDeath;

    public virtual void Start() {
        health = startingHealth;
    }

    public void TakeDamage(float damage, RaycastHit hit) {
        health -= damage;
        if(health<=0 && !dead) {
            Die();
        }
    }

    public void Die() {
        dead = true;
        if(OnDeath!=null) {
            OnDeath();
        }
        GameObject.Destroy(this.gameObject);
    }
}
