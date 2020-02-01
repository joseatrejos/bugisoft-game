using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameStateData
{
    public float[] position;
    public bool completedFirstPuzzle;
    public bool completedSecondPuzzle;
    public bool completedThirdPuzzle;
    public string scenename2;
    public string scenename;
    Scene scene;

    public GameStateData(GameState gameState) 
    {
        position = new float[3];
        position[0] = gameState.transform.position.x;
        position[1] = gameState.transform.position.y;
        position[2] = gameState.transform.position.z;
        scene = SceneManager.GetActiveScene();
        scenename = gameState.scene.name;

        completedFirstPuzzle = gameState.completedFirstPuzzle;
        completedSecondPuzzle = gameState.completedSecondPuzzle;
        completedThirdPuzzle = gameState.completedThirdPuzzle;
    }
}
