using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour
{

    Animator m_Animator;
    private bool Up = false;
    private bool Down = false;
    private bool Left = false;
    private bool Right = false;

    private bool Up_Idle = false;
    private bool Down_Idle = false;
    private bool Left_Idle = false;
    private bool Right_Idle = false;

    private bool Attack_On = false;

    // Use this for initialization
    void Start ()
    {
        m_Animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //These link to the PlayerAnimatorController for the sprite movement changes
        m_Animator.SetBool("Up", Up);
        m_Animator.SetBool("Down", Down);
        m_Animator.SetBool("Left", Left);
        m_Animator.SetBool("Right", Right);

        m_Animator.SetBool("Up_Idle", Up_Idle);
        m_Animator.SetBool("Down_Idle", Down_Idle);
        m_Animator.SetBool("Left_Idle", Left_Idle);
        m_Animator.SetBool("Right_Idle", Right_Idle);

        m_Animator.SetBool("Attack_On", Attack_On);


    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        if(v == 0 || v > 0 || v < 0)
        {
            //CheckForAttack();
        }

        if (h == 0 || h > 0 || h < 0)
        {
            //CheckForAttack();
        }

        //Up
        if (v > 0)
        {
            Up_Idle = true;
            Down_Idle = false;
            Left_Idle = false;
            Right_Idle = false;

            Up = true;
            Down = false;
            Left = false;
            Right = false;
            CheckForAttack();

        }

        //Down
        else if(v < 0)
        {
            Down_Idle = true;
            Up_Idle = false;
            Left_Idle = false;
            Right_Idle = false;

            Down = true;
            Up = false;
            Left = false;
            Right = false;
            CheckForAttack();
        }

        //Right
        else if(h > 0)
        {
            Right_Idle = true;
            Down_Idle = false;
            Left_Idle = false;
            Up_Idle = false;

            Right = true;
            Up = false;
            Down = false;
            Left = false;
            CheckForAttack();
        }

        //Left
        else if (h < 0)
        {
            Left_Idle = true;
            Down_Idle = false;
            Up_Idle = false;
            Right_Idle = false;

            Left = true;
            Up = false;
            Down = false;
            Right = false;
            CheckForAttack();
        }

        else
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
            CheckForAttack();
        }
    }

    private void CheckForAttack()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Attack_On = true;
            return;
        }

        else
        {
            Attack_On = false;
            return;
        }
    }
}
