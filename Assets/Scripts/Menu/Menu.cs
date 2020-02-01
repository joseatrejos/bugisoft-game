using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("New game starts");
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit(){
        Debug.Log("Close window");
        Application.Quit();
    }
}
