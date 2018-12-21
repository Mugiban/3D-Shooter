﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : Character
{

    UnityEngine.AI.NavMeshAgent pathfinder;

    Transform target;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = FindObjectOfType<Player>().transform;


        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator UpdatePath() {
        float refreshRate = 0.25f;
        while(target!=null) {
            Vector3 targetPosition = new Vector3(target.position.x, 0f, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
