using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedChick : MonoBehaviour
{
    public GameObject PlayerRef, ChickPosRef;
    private AudioSource playerAudioSource;
    private ScoreManager scoreManagerRef;

    private void Awake()
    {
        PlayerRef = GameObject.Find("Player");
        ChickPosRef = GameObject.Find("ChicksPosRef");
        playerAudioSource = PlayerRef.GetComponent<AudioSource>();
        scoreManagerRef = GameObject.Find("UIManager").GetComponent<ScoreManager>();
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Chick")
        {
            if (!other.GetComponent<Chicken>().isBig)
            {
                other.GetComponent<Chicken>().isBig = true;
                playerAudioSource.PlayOneShot(other.GetComponent<Chicken>().GrowUpSound);
                other.GetComponentInChildren<Animator>().Play("Growup");
                scoreManagerRef.AddScore(1);
            }
           
            other.transform.localScale = new Vector3(1,1,1);
        }
    }
}
