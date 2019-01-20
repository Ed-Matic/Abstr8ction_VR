using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;

    public float healthBarLength;

    public Texture2D healthBar;

    public bool lockOn;
    private bool alive = true;

    EnemyAI ea;


    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 2;

        ea = (EnemyAI)GetComponent("EnemyAI");
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentHealth(0);
        

    }

    //Drawing the Health Bar GUI on the Screen
    void OnGUI()
    {
        lockOn = ea.targetLock;
        if (lockOn == true && alive == true)
        {
            GUI.DrawTexture(new Rect(10, 40, healthBarLength, 20), healthBar);
            GUI.Box(new Rect(10, 40, healthBarLength, 20), "Enemy Health:  " + currentHealth + "/" + maxHealth);
        }
        //GUI.Box(new Rect(10, 40, healthBarLength, 20), "Enemy Health:  " + currentHealth + "/" + maxHealth);
    }

    public void AdjustCurrentHealth(int adj)
    {
        //Adds positive/negative points to the current health bar. either damage or potions
        currentHealth += adj;

        //Making sure the health does not go below 0 or above 100
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            alive = false;
            Destroy(this.gameObject);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        //Checking to make sure no max or scaling error
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        //Full length of health bar multiplying it by the percentage of our current health
        healthBarLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);
    }
}
