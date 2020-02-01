using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStateData
{
    public float[] position;
    public bool completedFirstPuzzle;
    public bool completedSecondPuzzle;
    public bool completedThirdPuzzle;

    public GameStateData(GameState gameState) 
    {
        position = new float[3];
        position[0] = gameState.transform.position.x;
        position[1] = gameState.transform.position.y;
        position[2] = gameState.transform.position.z;

        completedFirstPuzzle = gameState.completedFirstPuzzle;
        completedSecondPuzzle = gameState.completedSecondPuzzle;
        completedThirdPuzzle = gameState.completedThirdPuzzle;
    }
}
