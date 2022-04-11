using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlayerCollect : MonoBehaviour
{
    public GameObject ChikenPosRef, PlayerRef, FinishLine, PlayerChickHouse, FinishParticle;
    private bool isfull = false;
    private AudioSource PlayerAudioSource;
    public AudioClip FinishCollectSound;
    public GameObject PathFollower;
    public GameObject EndGameui;
    public GameObject inGameui;
    [SerializeField]
    private GameObject[] Eggs;

    public bool ScoreEnable = false;

    private void Awake()
    {
        PlayerRef = GameObject.Find("Player");
        PlayerAudioSource = PlayerRef.GetComponent<AudioSource>();
        ChikenPosRef = GameObject.Find("ChicksPosRef");
        FinishLine = GameObject.Find("FinishLine");
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isfull)
        {
            isfull = true;

            PlayerRef.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.parent = PlayerChickHouse.gameObject.transform;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.transform.localRotation = new Quaternion(0, 0, 0, 0);
            PlayerAudioSource.PlayOneShot(FinishCollectSound);
            PlayerChickHouse.gameObject.GetComponentInChildren<Animator>().SetBool("Finish", true);
            FinishParticle.SetActive(true);
            FinishParticle.GetComponent<ParticleSystem>().Play();
            StartCoroutine(ShowEggScore());
        }
    }



    IEnumerator ShowEggScore()
    {
        if (!ScoreEnable)
        {
            ScoreEnable = true;
            for (int i = 0; i < FinishLine.GetComponent<FinishLineScript>().ChickenCount; i++)
            {
                yield return new WaitForSecondsRealtime(0.1f);
                Eggs[i].SetActive(true);
                PlayerRef.transform.localPosition = new Vector3(Eggs[i].gameObject.transform.localPosition.x, Eggs[0].gameObject.transform.localPosition.y + 0.5f + i * 0.2f, Eggs[i].gameObject.transform.localPosition.z);
                FinishParticle.transform.localPosition = PlayerRef.transform.localPosition / 2;
            }
            yield return new WaitForSecondsRealtime(0.5f);
            GameStatusEvent.Status.LevelEnded();
        }




    }


}

