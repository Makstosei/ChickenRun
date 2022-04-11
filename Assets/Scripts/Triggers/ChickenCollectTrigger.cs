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


    //player collect trigger içindeki fonksiyonun aynýsý olduðundan orayý çalýþtýrýyoruz.

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chick" && other.GetComponent<Chicken>().isCollected == false)
        {
            PlayerRef.GetComponent<PlayerCollectTrigger>().CollectChick(other);
        }
    }
}
