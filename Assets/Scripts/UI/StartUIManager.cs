using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameStatusEvent.onGameStarted += OnGamestarted;
    }

  

    private void OnDisable()
    {
        GameStatusEvent.onGameStarted -= OnGamestarted;
    }


    private void OnGamestarted()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

   
}
