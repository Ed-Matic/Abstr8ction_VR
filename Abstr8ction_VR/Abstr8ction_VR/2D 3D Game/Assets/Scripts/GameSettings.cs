using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{
    public const string PLAYER_SPAWN_POINT = "Player Spawn Point"; // This is the name of the gameobject that the player will spawn on at the start of the level

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void SaveCharacterData()
    {

    }

    void LoadCharacterData()
    {

    }
}
