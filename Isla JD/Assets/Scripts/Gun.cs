using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject pref_Bullet;
    public Transform spawnPoint;
    public float velocityOfBullet;
    public int maxMagazine = 5;
    private int actualMagazine;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && actualMagazine > 0)
        {
            GameObject go = Instantiate(pref_Bullet, spawnPoint.position, spawnPoint.rotation);
            go.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * velocityOfBullet, ForceMode.Impulse);

            Destroy(go, 2f);

            actualMagazine--;
        }

        if(Input.GetButtonDown("Reload"))
        {
            Reload();
        }

    }

    private void Reload()
    {
        actualMagazine = maxMagazine;
    }
}
