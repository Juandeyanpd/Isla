using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyController : MonoBehaviour
{
    public MovementController movement;
    public Transform jugador;
    public float rangeOfDetection = 15f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, jugador.position);

        /*if(distance <= rangeOfDetection)
        {
            movement.Move( 0, 1);
        }*/

        Vector3 toJugador = jugador.position - transform.position;

        if (distance <= rangeOfDetection && Vector3.Dot(transform.forward, toJugador.normalized) < 0.95f)
        {
            movement.Rotate(1);
        }

        if(Vector3.Dot(transform.forward, toJugador) < 0)
        {
            Debug.Log("He is behind you");
        }
          
        if(Vector3.Dot(transform.forward, toJugador) > 0)
        {
            Debug.Log("He is forward you");
        }

        if(Vector3.Dot(transform.right, toJugador) < 0)
        {
            Debug.Log("He is left you");
        }

        if (Vector3.Dot(transform.right, toJugador) > 0)
        {
            Debug.Log("He is rigth you");
        }

    }
}
