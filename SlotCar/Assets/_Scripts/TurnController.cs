using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public SlotCarController cc;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Turn"))
        {
            cc.setGoalRotation(other.gameObject.transform.rotation);
        }
        else if (other.gameObject.tag.Equals("Spawn")) {
            cc.spawnPoint = other.gameObject.transform;
        }
    }

}
