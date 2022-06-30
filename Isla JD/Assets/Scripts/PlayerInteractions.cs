using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public StadisticsOfPlayer playerState;
    public AudioSource indicador;

    public GameObject BolsilloDeArma;
    //public GameObject gun;
    public Transform cameraPlayer;
    public Transform objetoVacio;
    public LayerMask lm;
    public LayerMask lMGun;
    public float rayDistance;
    private void Update()
    {

        if (Input.GetButtonDown("PickButton"))
        {
            if (objetoVacio.childCount > 0)
            {
                objetoVacio.GetComponentInChildren<Rigidbody>().isKinematic = false;
                objetoVacio.DetachChildren();
                if (BolsilloDeArma.transform.childCount > 0)
                {
                    BolsilloDeArma.transform.GetChild(0).gameObject.SetActive(true);
                }
            }

            else
            {
                Debug.DrawRay(cameraPlayer.position, cameraPlayer.forward * rayDistance, Color.blue);
                if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out RaycastHit hit, rayDistance, lm))
                {
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.parent = objetoVacio;
                hit.transform.localPosition = Vector3.zero;
                hit.transform.localRotation = Quaternion.identity;

                if (BolsilloDeArma.transform.childCount > 0)
                    {
                        BolsilloDeArma.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //Coger Arma
            if (other.tag == "Gun")
            {
               other.transform.parent = BolsilloDeArma.transform;
               other.transform.localPosition = Vector3.zero;
               other.transform.localRotation = Quaternion.identity; 

                if(objetoVacio.childCount > 0)
                {
                 BolsilloDeArma.transform.GetChild(0).gameObject.SetActive(false);
                }
            }

        //Reproducción de la animación de la puerta
        if (other.tag == "Door" && playerState.batteryCount >= 2)
        { 
        other.GetComponentInParent<Door>().OnOpenDoor();
        }

        //Reproducción del sonido al tocar las pastillas
        if(other.tag == "Battery")
        {
            other.gameObject.SetActive(false);

            if(gameObject.activeSelf == true)
            {
                Instantiate(indicador);
            }
            playerState.batteryCount++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
