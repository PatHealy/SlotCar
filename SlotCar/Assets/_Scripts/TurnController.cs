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
        else if (other.gameObject.tag.Equals("RedSpawn")) {
            if (cc.playNum == 1)
            {
                cc.spawnPoint = other.gameObject.transform;
            }
        }
        else if (other.gameObject.tag.Equals("BlueSpawn"))
        {
            if (cc.playNum == 2)
            {
                cc.spawnPoint = other.gameObject.transform;
            }
        }
    }

}
