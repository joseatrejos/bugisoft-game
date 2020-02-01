using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float speed = 10f;
    public bool completedFirstPuzzle = false;
    public bool completedSecondPuzzle = false;
    public bool completedThirdPuzzle = false;
    public string scenename;

    public void NewGame()
    {
        Debug.Log("New game starts");
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGame(){
        GameStateData data = SaveSystem.LoadGameState();
        SceneManager.LoadScene(data.scenename);

        completedFirstPuzzle = data.completedFirstPuzzle;
        completedSecondPuzzle = data.completedSecondPuzzle;
        completedThirdPuzzle = data.completedThirdPuzzle;
    }
    public void Exit(){
        Debug.Log("Close window");
        Application.Quit();
    }
}
