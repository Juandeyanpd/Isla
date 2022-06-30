using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforme : MonoBehaviour
{
    public GameObject plataform;
    public GameObject button;
    public float velocity;
    public GameObject maxposition;
    public GameObject minposition;

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            MovePlataform();
        }
    }
    private void MovePlataform()
    {
        plataform.transform.Translate(Vector3.up * Time.deltaTime * velocity);

        if(plataform.transform.position.y >= maxposition.transform.position.y)
        {
            velocity = velocity * -1;
        }
        if(plataform.transform.position.y <= minposition.transform.position.y)
        {
            velocity = velocity * -1;
        }
    }
    
}
