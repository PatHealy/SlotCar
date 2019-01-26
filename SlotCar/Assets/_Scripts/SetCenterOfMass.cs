using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenterOfMass : MonoBehaviour {
    public Transform cm;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().centerOfMass = cm.localPosition;
    }
}
