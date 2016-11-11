using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public int scoreValue;
    protected GameController gameController;
    protected int hitCount=0;
    public int shieldsStrength;
    public string[] myWeapon;

    public virtual  void Start()
    {
     
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

	public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary" ||  myWeapon.Contains(other.tag))
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Debug.Log(gameController);
        if (gameController != null)
        {
            gameController.AddScore(scoreValue);
        }
        
        hitCount++;

        if (hitCount >= shieldsStrength)
        {
            Destroy(gameObject);
        }
    
    }
}
