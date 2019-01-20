using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour 
{
	public Transform camcam;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = camcam.position + new Vector3 (-5, 20,-18);
	}
}
