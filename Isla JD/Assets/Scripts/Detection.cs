using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    // Start is called before the first frame update
  void onTriggerEnter()
    {
        Debug.Log("Entra");
    }

    void onTriggerStay()
    {
        Debug.Log("Permanece Adentro");
    }

    void onTriggerExit()
    {
        Debug.Log("Sale");
    }
}
