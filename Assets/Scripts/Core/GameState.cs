using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public float speed = 10f;
    public bool completedFirstPuzzle = false;
    public bool completedSecondPuzzle = false;
    public bool completedThirdPuzzle = false;
    public string scenename;
    public Scene scene;

    public void SaveGameState()
    {
        SaveSystem.SaveGameState(this);
    }

    public void LoadGameState()
    {
        GameStateData data = SaveSystem.LoadGameState();

        SceneManager.LoadScene(data.scenename);
        
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

