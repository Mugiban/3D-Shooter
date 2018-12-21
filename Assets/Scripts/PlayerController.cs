﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rgbd;
    Vector3 velocity;


    private void Start() {
        rgbd = GetComponent<Rigidbody>();
    }

    public void LookAt(Vector3 lookPoint) {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void Move(Vector3 moveVelocity) {
        velocity = moveVelocity;
    }

    void FixedUpdate() {
        rgbd.MovePosition(rgbd.transform.position + velocity * Time.fixedDeltaTime);
    }
}
