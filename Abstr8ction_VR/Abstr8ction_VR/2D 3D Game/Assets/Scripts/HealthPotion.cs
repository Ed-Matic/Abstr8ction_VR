using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour
{
    public GameObject target;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
        //ph.AdjustCurrentHealth(-5);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
            ph.AdjustCurrentHealth(+10);
            Destroy(this.gameObject);
        }

    }
}
