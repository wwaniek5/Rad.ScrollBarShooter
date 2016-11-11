using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float rotationSpeed;

    void Start () {
	    var asteroid= GetComponent<Rigidbody2D>();
        asteroid.angularVelocity = (float)(Random.value - 0.5) * rotationSpeed;
    }
	

}
