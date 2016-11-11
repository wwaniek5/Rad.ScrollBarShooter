using UnityEngine;
using System.Collections;
using System;

public class KlingonController : DestroyByContact {
    public float fireRate;
    private float nextFire;
    public GameObject shot;
    public Transform shotSpawn;

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

    }
}
