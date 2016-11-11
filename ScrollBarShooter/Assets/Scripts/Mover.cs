using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float Speed;

	void Start () {
        var phaser = GetComponent<Rigidbody2D>();
        var dsw = transform.forward * Speed;
        phaser.velocity = transform.up * Speed;
    }
	
	
}
