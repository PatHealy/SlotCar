using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {
    public static Director instance;
	void Awake () {
        instance = this;
	}
}
