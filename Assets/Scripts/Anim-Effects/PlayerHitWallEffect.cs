using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitWallEffect : MonoBehaviour
{
    public GameObject PlayerRef, ChickenPosRef, PathFollower;
    public int backwardspeed;
    public void WhenhitWallActivator()
    {
        StartCoroutine(Whenhitwall());
    }


    public IEnumerator Whenhitwall()
    {
        PathFollower.GetComponent<PathCreation.Examples.PathFollower>().speed = backwardspeed;
        yield return new WaitForSecondsRealtime(1.5f);
        PathFollower.GetComponent<PathCreation.Examples.PathFollower>().speed = 3;
    }


}




