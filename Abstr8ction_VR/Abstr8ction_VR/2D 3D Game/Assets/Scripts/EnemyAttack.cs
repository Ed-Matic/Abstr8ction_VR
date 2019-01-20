using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{

    public GameObject target;
    public GameObject prefab;
    public float attackTimer;
    public float coolDown;
    public bool attackOn = false;

    private string enemyName;
    private Collision col;
    private EnemyAI ei;

    Animator m_Animator;

    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        ei = (EnemyAI)GetComponent("EnemyAI");
        attackTimer = 0;
        coolDown = 2.0f;

        target = GameObject.FindGameObjectWithTag("Player");
        prefab = Resources.Load("Bullet")as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if (attackTimer < 0)
        {
            attackTimer = 0;
        }

        if (attackTimer == 0)
        {
            enemyName = this.gameObject.name;

            //Debug.Log(enemyName); // this is to see which object / enemy the script is applies to

            // Different Attack types for different kinds of enemies
            if(enemyName == "Enemy Melee")
            {
                MeleeAttack();
            }

            if(enemyName == "Enemy Shooter")
            {
                ShooterAttack();
            }

            if(enemyName == "Enemy Charger")
            {
                ChargerAttack();
            }

            //Attack();
            attackTimer = coolDown;
        }
        m_Animator.SetBool("AttackOn", attackOn);

    }


    //Attack method for the enemy that brawls with the player close range
    private void MeleeAttack()
    {
        //To check how far the player is from the enemy
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized;

        float direction = Vector3.Dot(dir, transform.forward);

        //checker to see our distance from the enemy and direction
        //Debug.Log(distance);
        //Debug.Log(direction);

        if (distance <= 6)
        {
            if (direction > 0)
            {
                attackOn = true;
                PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
                ph.AdjustCurrentHealth(-5);
            }
            else
            {
                //attackOn = false;
            }

        }
        else
        {
            attackOn = false;
        }
    }

    //Attack method for the enemy that shoots at the player from a distance
    private void ShooterAttack()
    {
        ei.maxDistance = 10;
        //To check how far the player is from the enemy
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized;

        float direction = Vector3.Dot(dir, transform.forward);

        //checker to see our distance from the enemy and direction
        //Debug.Log(distance);
        //Debug.Log(direction);

        if (distance > 6.0f && distance < 15.0f)
        {
            if (direction > 0)
            {

                attackOn = true;

                GameObject projectile = Instantiate(prefab) as GameObject;
                projectile.transform.position = transform.position - Camera.main.transform.forward;


                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = - Camera.main.transform.forward * 20;

                PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
                ph.AdjustCurrentHealth(-5);
            }
            else
            {
                //attackOn = false;
            }

        }
        else
        {
            attackOn = false;
            //ei.moveSpeed = -5;
        }

        if (distance < 6.0f)
        {
            ei.moveSpeed = -2;
        }
    }


    //Attack method for the enemy that charges at the player head on
    private void ChargerAttack()
    {
        //To check how far the player is from the enemy
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized;

        float direction = Vector3.Dot(dir, transform.forward);

        //checker to see our distance from the enemy and direction
        //Debug.Log(distance);
        //Debug.Log(direction);

        if (distance <= 10)
        {
            if (direction > 0)
            {

                ei.moveSpeed += 10;
                ei.rotationSpeed = 0;
                attackOn = true;

                if (distance <= 2)
                {
                    ei.moveSpeed = 2;
                    PlayerHealth ph = (PlayerHealth)target.GetComponent("PlayerHealth");
                    ph.AdjustCurrentHealth(-5);
                }
            }
            else
            {
                //attackOn = false;
                ei.moveSpeed = 2;
                ei.rotationSpeed = 3;
            }

        }
        else
        {
            attackOn = false;
            ei.moveSpeed = 2;
            ei.rotationSpeed = 3;
        }
    }

}
