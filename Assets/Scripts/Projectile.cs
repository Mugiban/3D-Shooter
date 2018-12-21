using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed = 20f;

    public LayerMask collisionMask;

    public void SetSpeed(float newSpeed) {
        moveSpeed = newSpeed;
    }

    private void Update() {
        float moveDistance = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistance);
        Destroy(this.gameObject, 5f);
        CheckCollisions(moveDistance);
    }

    void CheckCollisions(float moveDistance) {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) {
            Debug.Log("Hitting");
            OnHitObject(hit);
        }

    }

    void OnHitObject(RaycastHit newHit) {
        Destroy(this.gameObject);
    }
}
