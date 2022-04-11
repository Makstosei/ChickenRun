using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTrapsRandomer : MonoBehaviour
{
    public GameObject Trap1,Trap2,Trap3;

    private void Awake()
    {
        int random =Random.Range(1, 4);

        if (random ==1)
        {
            Trap1.SetActive(false);
            Trap2.SetActive(true);
            Trap3.SetActive(true);
        }
        else if(random==2)
        {
            Trap1.SetActive(true);
            Trap2.SetActive(false);
            Trap3.SetActive(true);
        }
        else
        {
            Trap1.SetActive(true);
            Trap2.SetActive(true);
            Trap3.SetActive(false);
        }
    }

}
