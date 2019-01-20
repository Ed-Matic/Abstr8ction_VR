using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC_Dialog : MonoBehaviour
{

    public string[] ansewrButtons;
    public string[] Questions;
    public int maxQuestions;
    public int maxAnswers;
    public int friendsFound;


    bool displayDialog = false;
    bool activateQuest = false;
    bool foundNPC = false;
    int questionNum = 0;
    int nextquestion = 0;
    GameObject Player;

    private Text textDialog;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerBody");
        maxQuestions = Questions.Length;
        maxAnswers = ansewrButtons.Length;

        textDialog = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        QuestObjective();
    }



    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(Screen.width / 2, Screen.height / 2, 250, 250));

        if (displayDialog && !activateQuest && Player)
        {
            if (questionNum < maxQuestions)
            {
                GUILayout.Label(Questions[questionNum]);
                if (questionNum == 0)
                {
                    if (GUILayout.Button(ansewrButtons[0]))
                    {
                        questionNum++;
                        nextquestion++;

                    }

                    if (GUILayout.Button(ansewrButtons[1]))
                    {
                        displayDialog = false;
                    }

                }


                if (nextquestion == 1)
                {
                    if (GUILayout.Button(ansewrButtons[2]))
                    {
                        questionNum++;
                        nextquestion++;
                    }

                    if (GUILayout.Button(ansewrButtons[3]))
                    {
                        displayDialog = false;
                        nextquestion = 0;
                        questionNum = 0;
                    }
                }

                if (nextquestion == 2)
                {
                    if (GUILayout.Button(ansewrButtons[4]))
                    {
                        activateQuest = true;
                        displayDialog = false;
                        foundNPC = true;
                    }
                }
            }

            /*if(questionNum == maxQuestions)
            {
                activateQuest = true;
                displayDialog = false;
            }*/




            //GUILayout.Label(Questions[1]);
        }

        if (displayDialog && activateQuest)
        {
            GUILayout.Label(Questions[2]);
            if (GUILayout.Button(ansewrButtons[4]))
            {
                displayDialog = false;
            }
        }


        GUILayout.EndArea();

    }

    void OnTriggerEnter()
    {
        displayDialog = true;

    }


    void OnTriggerExit()
    {
        displayDialog = false;
    }

    void QuestObjective()
    {
        if (foundNPC == true)
        {
            //friendsFound += 1;
            //Debug.Log("Found friend = " + friendsFound);

            if (friendsFound == 4)
            {
                //end game here
                Application.LoadLevel(0);
            }
        }

        foundNPC = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            friendsFound++;
            Debug.Log("Found friend = " + friendsFound);
            Destroy(this.gameObject);
        }
    }
}
