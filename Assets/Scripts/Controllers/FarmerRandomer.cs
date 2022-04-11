using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerRandomer : MonoBehaviour
{
    public GameObject Farmer1, Farmer2;

    private void Awake()
    {
        int random =Random.Range(1, 3);

        if (random ==1)
        {
            Farmer1.SetActive(true);
            Farmer2.SetActive(false);
        }
        else
        {
            Farmer2.SetActive(true);
            Farmer1.SetActive(false);
        }
    }

}
