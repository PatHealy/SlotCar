using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TubsBehavior : MonoBehaviour {
    NavMeshAgent ai;
    public Transform[] dest;
    public float threshold;
    Animator anim;
    float stopTime = -1.0f;
    float maxSpeed;
    float maxASpeed;
    Transform d;

	// Use this for initialization
	void Start () {
        ai = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        maxSpeed = ai.speed;
        maxASpeed = ai.angularSpeed;
        ai.destination = dest[0].position;
        StartCoroutine(shiftTarget());
	}

    IEnumerator shiftTarget()
    {
        while (true) {
            yield return new WaitForSeconds(10f);
            float nm = Random.Range(0, 2);
            if(nm > 0.5) {
                d = dest[0];
                //print("Go 0!");
            }
            else
            {
                d = dest[1];
                //print("Go 1!");
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if(d != null)
            ai.destination = d.position;
        float dist = Vector3.Distance(transform.position, d.position);
        if (dist < threshold) {
            ai.speed = 0f;
            ai.angularSpeed = 0f;
            anim.SetFloat("Move", 0);
            if(stopTime < 0) {
                stopTime = Time.fixedTime;
            }
            else {
                float timeSinceStop = Time.fixedTime - stopTime;
                if(timeSinceStop > 5) {
                    anim.SetBool("Sit", true);
                }
            }
        }
        else
        {
            ai.angularSpeed = maxASpeed;
            stopTime = -1f;
            anim.SetBool("Sit", false);
            if(dist > 30f) {
                anim.SetFloat("Move", 5);
                ai.speed = maxSpeed*4;
            }
            else if (dist > 20f)
            {
                anim.SetFloat("Move", 4);
                ai.speed = maxSpeed*3;
            }
            else if (dist > 15f)
            {
                anim.SetFloat("Move", 3);
                ai.speed = maxSpeed*2;
            }
            else if (dist > 10f)
            {
                anim.SetFloat("Move", 2);
                ai.speed = maxSpeed;
            }
            else
            {
                anim.SetFloat("Move", 1);
                ai.speed = maxSpeed;
            }
        }
    }
}
