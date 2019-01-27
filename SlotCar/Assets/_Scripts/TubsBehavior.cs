using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TubsBehavior : MonoBehaviour {
    NavMeshAgent ai;
    public Transform dest;
	// Use this for initialization
	void Start () {
        ai = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        ai.destination = dest.position;
	}
}
