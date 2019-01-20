using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject target;
    public float attackTimer;
    public float coolDown;

	// Use this for initialization
	void Start ()
    {
        attackTimer = 0;
        coolDown = 2.0f;
        target = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if(attackTimer < 0)
        {
            attackTimer = 0;
        }
        //Checking for keyboard input for attack: F key on keyboard or x button (A.K.A Joystick1Button2) on controller
        if (Input.GetKeyUp(KeyCode.F)|| Input.GetKeyUp(KeyCode.Joystick1Button2))
        {
            if(attackTimer == 0)
            {
                Attack();
                attackTimer = coolDown;
            }
        }
     
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            target = other.gameObject;
        }
    }

    private void Attack()
    {
        //To check how far the player is from the enemy
        if (target == null)
        {

        }
        else
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            Vector3 dir = (target.transform.position - transform.position).normalized;

            float direction = Vector3.Dot(dir, transform.forward);

            //checker to see our distance from the enemy and direction
            //Debug.Log(distance);
            Debug.Log(direction);

            if (distance <= 12)
            {
                if (direction > 0)
                {
                    EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
                    eh.AdjustCurrentHealth(-55);
                }

            }
        }
    }
}
