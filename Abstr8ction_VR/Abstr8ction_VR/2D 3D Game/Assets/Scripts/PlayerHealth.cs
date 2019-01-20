using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public float healthBarLength;

    public Texture2D healthBar;

    public float fillTime = 2f;
    private Slider myHealthSlider;
    private float timer;
    private Coroutine fillHealthBarRoutine;


    int foundFriends;

    // Use this for initialization
    void Start ()
    {
        healthBarLength = Screen.width / 2;

        myHealthSlider = GetComponent<Slider>();

        if (myHealthSlider == null) { Debug.Log("Could not Find VR health Slider"); }
    }
	
	// Update is called once per frame
	void Update ()
    {
        AdjustCurrentHealth(0);
    }

    //public void PointerE() { }

    //Drawing the Health Bar GUI on the Screen
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, healthBarLength, 20), healthBar);
        GUI.Box(new Rect(10, 10, healthBarLength, 20), "Player Health:  " + currentHealth + "/" + maxHealth);

        GUI.Box(new Rect(440, 10, (Screen.width / 2) - 60, 100), "Main Mission: \n Find The Portal Out \n  \n  Optional Objective: \n Find and Help your friends");


    }

    public void AdjustCurrentHealth(int adj)
    {
        //Adds positive/negative points to the current health bar. either damage or potions
        currentHealth += adj;
        fillHealthBarRoutine = StartCoroutine(FillBar());

        //Making sure the player health does not go below 0 or above 100
        if (currentHealth <= 0)
        {
            //currentHealth = 0;
            Application.LoadLevel(6);
        }

        if(currentHealth > maxHealth)
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

        //myHealthSlider.value = healthBarLength;

        //fillHealthBarRoutine = StartCoroutine(FillBar());
    }

    private IEnumerator FillBar()
    {
        /*timer = 0f;

        while (timer < fillTime)
        {
            timer += Time.deltaTime;

            myHealthSlider.value = currentHealth*timer; //* (timer/ fillTime);

            yield return null;

        }*/

        myHealthSlider.value = currentHealth;
        yield return null;
    }
}
