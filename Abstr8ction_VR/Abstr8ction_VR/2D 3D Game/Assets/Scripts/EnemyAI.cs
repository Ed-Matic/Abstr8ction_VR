using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform target;    //targeting the player
    public int moveSpeed;      // how fast the enemy will move
    public int rotationSpeed; // how fast the enemy will rotate
    public int maxDistance;  // Maximum distance from the player to chase
    public int minDistance; // Minimum distance from the player to chase
    public bool targetLock = false;

    

    private Transform myTransform;



    //This is called before anything else in the script
    void Awake()
    {
        //this looks at where my initial position/transform is
        myTransform = transform;
    }

	// Use this for initialization
	void Start ()
    {

        //this locks on only the Gameobject with the tag Player
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;
        maxDistance = 2;
        minDistance = 15;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Draws a line/path from the enemy to the player/target. a little path finder
        Debug.DrawLine(target.position, myTransform.position, Color.yellow);


        //Look at our target
        //takes the enemy's transform and slowly turns its rotation to face the target(the use of Quaternion.Slerp). 
        //Looks at target position(a), then itself (b), and rotates it from a to b and how much to rotate by
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);


        //This checks if the enemy is within the required distance to chase us. if is not too close of too far.
        if (Vector3.Distance(target.position, myTransform.position) > maxDistance && Vector3.Distance(target.position, myTransform.position) < minDistance)
        {
            //Move towards our target
            Movement();
        }

        //Method to display the enemies health bar on screen. Linked to EnemyHealth script.
        if (Vector3.Distance(target.position, myTransform.position) >= 0 && Vector3.Distance(target.position, myTransform.position) < minDistance)
        {
            targetLock = true;
        }

        else
        {
            targetLock = false;
        }

	}


    void Movement()
    {
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }

    void Patrol()
    {

    }
}
