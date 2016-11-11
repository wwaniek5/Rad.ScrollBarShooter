using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System;
using UnityEngine.UI;

public class ShipController : DestroyByContact
{

    public float Speed;
    public float Tilt;
    public Boundary boundary;


    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire;
    public float fireRate;
  
    private bool hasTorpedos=false;
    private float nextTorpedo;
    public GameObject torpedo;
    public Text shields;

    public override void Start()
    {
        base.Start();
        shields.text = "shields: 100%";
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        if (Input.GetKey(KeyCode.X) && Time.time > nextTorpedo && hasTorpedos)
        {
            nextTorpedo = Time.time + fireRate/3;
            Instantiate(torpedo, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

       var ship= GetComponent<Rigidbody2D>();

        var velocityDirection= new Vector2(moveHorizontal, moveVertical);
        ship.velocity = velocityDirection * Speed;

        ship.position = new Vector2
        (
            Mathf.Clamp(ship.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(ship.position.y, boundary.yMin, boundary.yMax)
        );

        ship.rotation = ship.velocity.x * -Tilt;
    }

    internal void AddTorpedos()
    {
        hasTorpedos = true;
    }

    void OnDestroy()
    {
        gameController.infoText.text = "Koniec gry.Naciśnij 'R' żeby zrestartować";
        gameController.Stop();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
          shields.text = "shields: " + ((shieldsStrength - hitCount)*100 / shieldsStrength)+"%";
    }




}
