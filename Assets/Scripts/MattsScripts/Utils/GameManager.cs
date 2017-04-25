using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int RoundCount = 0;
    public bool Paused = false;
   

    void Awake()
    {
        RoundCount = 0;
        Paused = false;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
