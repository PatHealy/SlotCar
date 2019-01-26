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
            //print("Turn left!");
            cc.setGoalRotation(other.gameObject.transform.rotation);
        }
    }

}
