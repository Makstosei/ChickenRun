using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCollectTrigger : MonoBehaviour
{
    
    public GameObject PlayerRef;


    private void Awake()
    {
       
        PlayerRef = GameObject.Find("Player");

    }


    //player collect trigger i�indeki fonksiyonun ayn�s� oldu�undan oray� �al��t�r�yoruz.

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chick" && other.GetComponent<Chicken>().isCollected == false)
        {
            PlayerRef.GetComponent<PlayerCollectTrigger>().CollectChick(other);
        }
    }
}
