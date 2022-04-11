using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapManager : MonoBehaviour
{
    public GameObject PlayerRef, ChickPosRef, CollectableChicks;
    private int trappedchickindex;
    private List<Transform> actualChickenListRef;
    private AudioSource playerAudioSource;
    private ScoreManager scoreManagerRef;

    private void Awake()
    {
        PlayerRef = GameObject.Find("Player");
        ChickPosRef = GameObject.Find("ChicksPosRef");
        CollectableChicks = GameObject.Find("CollectableChicks");
        playerAudioSource = PlayerRef.GetComponent<AudioSource>();
        scoreManagerRef = GameObject.Find("UIManager").GetComponent<ScoreManager>();
    }


    private void Start()
    {
        actualChickenListRef = ChickPosRef.GetComponent<ChickenPosUpdater>().actualChicksList;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chick")
        {
            for (int i = actualChickenListRef.Count - 1; i > -1; i--)
            {
                if (actualChickenListRef[i] == other.transform)
                {
                    actualChickenListRef[i].gameObject.SetActive(false);
                    actualChickenListRef.Remove(actualChickenListRef[i]);
                    ChickPosRef.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
                    playerAudioSource.PlayOneShot(other.GetComponent<Chicken>().DestroySound);
                    if (other.GetComponent<Chicken>().isBig)
                    {
                        scoreManagerRef.DecreaseScore(2);
                    }
                    else
                    {
                        scoreManagerRef.DecreaseScore(1);
                    }
                  
                }
            } 
        }
        else if (other.tag == "Player")
        {

            GameStatusEvent.Status.TrapCaught();
        }




    }
}




