using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    Transform gate;
    NavMeshAgent navMesh;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        gate = GameObject.FindWithTag("Gate").transform;
    }

    private void Update()
    {
        navMesh.destination = gate.position;
    }
}
