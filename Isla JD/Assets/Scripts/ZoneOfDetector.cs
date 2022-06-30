using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneOfDetector : MonoBehaviour
{
    void onTriggerEnter()
    {
        Debug.Log("Picked Up Weapon");
    }

    void onTriggerStay()
    {

    }

    void onTriggerExit()
    {

    }
    
}
