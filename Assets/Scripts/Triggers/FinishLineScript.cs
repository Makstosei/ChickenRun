using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    private float positionx;
    public float sideMovement, maxSideMovement;
    public GameObject PlayerRef, ChikenPosRef;
    private bool isfull = false;
    public GameObject PathfollowerRef;
    public int ChickenCount;


    private void Awake()
    {

        PlayerRef = GameObject.Find("Player");
        ChikenPosRef = GameObject.Find("ChicksPosRef");
        sideMovement = PlayerRef.GetComponent<PlayerController>().sideMovement;
        maxSideMovement = PlayerRef.GetComponent<PlayerController>().maxSideMovement;
    }
    private void Update()
    {
        if (isfull)
        {
            if (PlayerRef.transform.localPosition.x != 0)
            {

                PlayerRef.GetComponent<PlayerController>().canMove = false;
                positionx = Mathf.Lerp(positionx, 0, sideMovement / 20);
                PlayerRef.transform.localPosition = new Vector3(positionx, PlayerRef.transform.localPosition.y, 0);
                PlayerRef.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isfull)
        {
            PathfollowerRef.GetComponent<PathCreation.Examples.PathFollower>().speed = 2f;
            isfull = true;
            
            foreach (var chick in ChikenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList)
            {
                if (chick.GetComponent<Chicken>().isBig)
                {
                    ChickenCount += 2;
                }
                else
                {
                    ChickenCount += 1;
                }

            }
        }





    }


}
