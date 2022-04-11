using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollectTrigger : MonoBehaviour
{
    
    public GameObject ChickPosRef;
    public float directionoffset;
    private AudioSource audioSource;
    private ScoreManager scoreManagerRef;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        scoreManagerRef= GameObject.Find("UIManager").GetComponent<ScoreManager>();
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Chick" && other.GetComponent<Chicken>().isCollected == false)
        {
            CollectChick(other);

        }
    }

    public void CollectChick(Collider other)
    {
       
        audioSource.PlayOneShot(other.GetComponent<Chicken>().CollectSound);
        other.transform.parent = ChickPosRef.gameObject.transform;
        ChickPosRef.GetComponent<ChickenPosUpdater>().actualChicksList.Insert(0,other.transform);
        other.GetComponent<Chicken>().isCollected = true;
        ChickPosRef.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
        other.GetComponentInChildren<Animator>().Play("Collect");
        other.GetComponentInChildren<Animator>().SetBool("isRunning", true);
        scoreManagerRef.AddScore(1);
    }

}
