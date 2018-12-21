using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
    Vector3 moveInput;
    public float moveSpeed = 5f;
    PlayerController controller;
    GunController gunController;
    Camera cam;
    
    void Start()
    {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        cam = Camera.main;
    }
    
    void Update()
    {
        //Movement input
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 moveVelocity = (moveInput * moveSpeed);
        controller.Move(moveVelocity);


        //look input
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            controller.LookAt(point);
            Debug.DrawLine(ray.origin, point, Color.red);
        }

        //weapon input
        if(Input.GetMouseButtonDown(0)) {
            gunController.Shoot();
        }
    }
}
