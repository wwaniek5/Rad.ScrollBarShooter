using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class BorgController : DestroyByContact {

    public float Speed;

    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire;
    public float fireRate;
    private int  moveRight=1;
    
    private Rigidbody2D ship;

    public override void Start()
    {
        base.Start();
         ship = GetComponent<Rigidbody2D>();
        ship.velocity = transform.up * Speed;


    }

    void Update()
    {
        if ( Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        if (ship.position.y < boundary.yMin)
        {
            ship.velocity = transform.right * Speed*moveRight;
        }

        if (ship.position.x > boundary.xMax && moveRight==1)
        {
            moveRight = -1 ;
        }


        if ( ship.position.x < boundary.xMin && moveRight == -1)
        {
            moveRight = 1;
        }
    }
    void OnDestroy()
    {
        gameController.infoText.text = "Zwycięstwo. Naciśnij 'R' żeby zrestartować";

    }





}
