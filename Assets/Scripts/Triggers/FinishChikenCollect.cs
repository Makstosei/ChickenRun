using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChikenCollect : MonoBehaviour
{
    public GameObject ChikenPosRef, PlayerRef;
    private bool isfull = false;
    private AudioSource PlayerAudioSource;
    public AudioClip FinishCollectSound;

    private void Awake()
    {
        PlayerRef = GameObject.Find("Player");
        PlayerAudioSource = PlayerRef.GetComponent<AudioSource>();
        ChikenPosRef = GameObject.Find("ChicksPosRef");

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isfull & ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList.Count > 0)
            {
                    isfull = true;
                    PlayerAudioSource.PlayOneShot(FinishCollectSound);
                    ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList[ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList.Count - 1].transform.parent = this.transform.GetChild(1).gameObject.transform;
                    ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList[ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList.Count - 1].localPosition = new Vector3(0, 0, 0);
                    ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList[ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList.Count - 1].localRotation = new Quaternion(0, 0, 0, 0);
                    ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList.RemoveAt(ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList.Count - 1); 
            }
        }
    }
}
