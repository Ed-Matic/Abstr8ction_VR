using UnityEngine;
using System.Collections;

public class Billboards : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //transform.LookAt(Camera.main.transform.position, Vector3.up);
        transform.forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1,0,1));

        CamAngle();
        
    }

    public void CamAngle()
    {
      
    }
}
