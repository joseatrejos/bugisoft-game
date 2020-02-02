using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    GameObject player;

    public GameObject Player {get => player; set => player = value; }

    Vector3 playerPos;

    public Vector3 PlayerPos{ get => playerPos; set => playerPos = value;}

    GameStateData gameData;

    public GameStateData GameData{ get => gameData; set => gameData = value; }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        /*GameStateData data = SaveSystem.LoadGameState();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
        */
    }
    
}
