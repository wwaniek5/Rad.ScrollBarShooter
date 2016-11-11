using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TorpedoController : MonoBehaviour {


    private ShipController shipController;


    public virtual void Start()
    {
    

        GameObject shipControllerObject = GameObject.FindWithTag("Player");
        if (shipControllerObject != null)
        {
            shipController = shipControllerObject.GetComponent<ShipController>();
        }

        if (shipController == null)
        {
            Debug.Log("error");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {

            shipController.AddTorpedos();
            Destroy(gameObject);

        }


    }


}
