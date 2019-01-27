using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class SlotCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public Quaternion goalRotation;
    public float steering;
    public float brakes;

    public Transform spawnPoint;
    public string inpA;
    public string inpR;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis(inpA);
        if (motor < 0)
            motor = 0;
        float turnDif = (goalRotation.eulerAngles.y - transform.rotation.eulerAngles.y);
        steering = turnDif;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                if(motor < maxMotorTorque/10f) {
                    //print(motor);
                    axleInfo.leftWheel.brakeTorque = brakes;
                    axleInfo.rightWheel.brakeTorque = brakes;
                }
                else
                {
                    axleInfo.leftWheel.brakeTorque = 0;
                    axleInfo.rightWheel.brakeTorque = 0;
                }
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void resetCar() {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.enabled = false;
                axleInfo.rightWheel.enabled = false;
            }
        }
        StartCoroutine(replaceCar());
    }

    public IEnumerator replaceCar()
    {
        MeshRenderer[] mr = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer m in mr) {
            m.enabled = false;
        }

        yield return new WaitForSeconds(0.4f);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.enabled = true;
                axleInfo.rightWheel.enabled = true;
            }
        }

        foreach (MeshRenderer m in mr)
        {
            m.enabled = true;
        }

        transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(inpR)) {
            resetCar();
        }
    }

    public void setGoalRotation(Quaternion rot) {
        //print("Set!");
        goalRotation = rot;
    }
}
