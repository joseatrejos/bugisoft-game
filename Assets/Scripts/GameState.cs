using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public float speed = 10f;
    public bool completedFirstPuzzle = false;
    public bool completedSecondPuzzle = false;
    public bool completedThirdPuzzle = false;

    public void SaveGameState()
    {
        SaveSystem.SaveGameState(this);
    }

    public void LoadGameState()
    {
        GameStateData data = SaveSystem.LoadGameState();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        completedFirstPuzzle = data.completedFirstPuzzle;
        completedSecondPuzzle = data.completedSecondPuzzle;
        completedThirdPuzzle = data.completedThirdPuzzle;
    }

    private void Update() 
    {
        //Debug.Log("UPDATE");
        // Placeholder
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("SAVING");
            SaveGameState();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("LOADING");
            LoadGameState();
        }
    }
}

