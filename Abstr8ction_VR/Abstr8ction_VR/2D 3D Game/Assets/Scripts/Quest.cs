using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour
{
    public GameObject target;

    private float distance;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerBody");

        distance = Vector3.Distance(target.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
        //ph.AdjustCurrentHealth(-5);

        


    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            if (Application.loadedLevel == 3) { Application.LoadLevel(4); }
            else if (Application.loadedLevel == 4) { Application.LoadLevel(5); }
            else if (Application.loadedLevel == 5) { Application.LoadLevel(7); }

            else { Application.LoadLevel(Application.loadedLevel); }
            //Application.LoadLevel(7);
        }
    }
}