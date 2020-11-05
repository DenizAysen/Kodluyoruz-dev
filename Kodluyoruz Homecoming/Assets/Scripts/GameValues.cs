//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{
    private static GameValues _instance;

    private GameValues _gameState;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);

    }

    public static GameValues Instance()
    {
        return _instance;
    }
    public float ball_speed;
    

}
