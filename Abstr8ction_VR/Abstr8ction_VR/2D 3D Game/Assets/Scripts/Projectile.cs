using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
        //ph.AdjustCurrentHealth(-5);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
            ph.AdjustCurrentHealth(-5);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("World"))
        {
            Destroy(this.gameObject);
        }
    }
}
