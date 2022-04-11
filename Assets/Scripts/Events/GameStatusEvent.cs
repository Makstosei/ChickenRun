using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStatusEvent : MonoBehaviour
{
    public static GameStatusEvent Status;
    public static Action onGameStarted;
    public static Action onGamePaused;
    public static Action onLevelEnded;
    public static Action onHitTrap;

   

    private void Awake()
    {
        Status = this;
    }



    public void GameStared()
    {
        if (onGameStarted != null)
        {
            onGameStarted();
         
        }
    }

    public void GamePaused()
    {
        if (onGamePaused != null)
        {
            onGamePaused();
        }
    }
    public void LevelEnded()
    {
        if (onLevelEnded != null)
        {
            onLevelEnded();
        }
    }

    public void TrapCaught()
    {
        if (onHitTrap != null)
        {
            onHitTrap();
        }
    }






}
