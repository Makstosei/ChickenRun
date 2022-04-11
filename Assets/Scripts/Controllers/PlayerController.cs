using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour//IPointerClickHandler,IPointerUpHandler,IPointerDownHandler
{

    public GameObject ChickPosRefer;
    public float sideMovement = 0.5f, maxSideMovement = 2;
    private float positionx;
    public float jumpheight = 1.5f;
    public float jumpspeed = 0.3f;
    public bool isGameStarted = false;
    public bool canMove = false;

    private bool iscorrectinglane;
    public float swipeRange;
    public float tapRange;
    public Vector2 firstPressPos;
    private Vector2 currentPos;
    private Vector2 secondPressPos;
    private bool stopTouch = false;

    




    private void OnEnable()
    {
        GameStatusEvent.onGameStarted += OnGamestarted;
        GameStatusEvent.onGamePaused += OnGamePaused;
    }
    private void OnDisable()
    {
        GameStatusEvent.onGameStarted -= OnGamestarted;
        GameStatusEvent.onGamePaused -= OnGamePaused;
    }

    private void OnGamePaused()
    {
        this.transform.gameObject.GetComponentInChildren<Animator>().SetBool("isRunning", false);
        GameStatusEvent.onGameStarted += OnGamestarted;
        canMove = false;
    }

    private void OnGamestarted()
    {
        GameStatusEvent.onGameStarted -= OnGamestarted;
       this.transform.gameObject.GetComponentInChildren<Animator>().SetBool("isRunning", true);
        canMove = true;
    }

    private void Update()
    {
       

        MoveCheck();

    }


    //public void OnPointerClick(PointerEventData eventData)
    //{

    //    if (!isGameStarted)
    //    {
    //        isGameStarted = true;
    //        GameStatusEvent.Status.GameStared();

    //    }
    //    stopTouch = false;
    //    firstPressPos = Input.mousePosition;
    //    Debug.Log("1: " + eventData.position);
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    currentPos = Input.mousePosition;
    //    Vector2 Distance = firstPressPos - currentPos;
    //    if (!stopTouch && canMove)
    //    {
    //        //sola kayd�rma
    //        if (Distance.x < -swipeRange)
    //        {
    //            positionx = Mathf.Clamp(positionx + sideMovement * Time.deltaTime, -maxSideMovement, maxSideMovement);
    //            transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
    //            ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
    //            GetComponent<PlayerRotatorEffect>().RightMovementEffect();
    //        }
    //        //sa�a kayd�rma
    //        else if (Distance.x > swipeRange)
    //        {
    //            positionx = Mathf.Clamp(positionx - sideMovement * Time.deltaTime, -maxSideMovement, maxSideMovement);
    //            transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
    //            ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
    //            GetComponent<PlayerRotatorEffect>().LeftMovementEffect();
    //        }

    //    }
    //    Debug.Log("2: " + eventData.position);
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    iscorrectinglane = true;
    //    stopTouch = true;
    //    secondPressPos = Input.mousePosition;
    //    Vector2 Distance = secondPressPos - firstPressPos;
    //    if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
    //    {
    //        //transform.gameObject.GetComponent<Rigidbody>().velocity+= jumpspeed*Vector3.up;
    //        // ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();

    //    }
    //    if (canMove)
    //    {
    //        StartCoroutine(GetComponent<PlayerRotatorEffect>().RotationResetCouroutine());
    //        ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
    //    }
    //    Debug.Log("3: " + secondPressPos);
    //    LaneCorrection();
    //}





    public void MoveCheck()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                GameStatusEvent.Status.GameStared();

            }
            stopTouch = false;
            firstPressPos = Input.mousePosition;

        }

        if (Input.GetMouseButton(0))
        {//bas�l� tutuldu�u m�ddet�e ba�lang�ca olan uzakl��� hesaplat�p sa�a m� sola m� gitti�ine g�re kayd�rma i�leminin ne y�ne oldu�una bak�yoruz. y check edilerek yukar� a�a��da yap�labilinir.
            currentPos = Input.mousePosition;
            Vector2 Distance = firstPressPos - currentPos;
            if (!stopTouch && canMove)
            {
                //sola kayd�rma
                if (Distance.x < -swipeRange)
                {
                    positionx = Mathf.Clamp(positionx + sideMovement * Time.deltaTime, -maxSideMovement, maxSideMovement);
                    transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                    ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
                    GetComponent<PlayerRotatorEffect>().RightMovementEffect();
                }
                //sa�a kayd�rma
                else if (Distance.x > swipeRange)
                {
                    positionx = Mathf.Clamp(positionx - sideMovement * Time.deltaTime, -maxSideMovement, maxSideMovement);
                    transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                    ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
                    GetComponent<PlayerRotatorEffect>().LeftMovementEffect();
                }

            }
        }

        //tap i�lemi
        if (Input.GetMouseButtonUp(0) && canMove)
        {
            iscorrectinglane = true;
            stopTouch = true;
            secondPressPos = Input.mousePosition;
            Vector2 Distance = secondPressPos - firstPressPos;
            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                //transform.gameObject.GetComponent<Rigidbody>().velocity+= jumpspeed*Vector3.up;
                // ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();

            }
            if (canMove)
            {
                StartCoroutine(GetComponent<PlayerRotatorEffect>().RotationResetCouroutine());
                ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
            }

        }

        //hareketi yapt�ktan sonra belirlenmi� bir kordinatta sabitliyoruz
        LaneCorrection();
    }


    //lane check i�inde de�i�keni aktif ederek �al��t�r�yoruz pozisyon e�itlendi�inde de�i�keni deaktif ediyoruz
    public void LaneCorrection()
    {
        if (iscorrectinglane && canMove)
        {

            if (transform.localPosition.x < -0.5 )
            {
                positionx = Mathf.Lerp(positionx, -1, sideMovement * Time.deltaTime);
                transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
                if (transform.localPosition.x < -0.97)
                {
                    positionx = -1;
                    transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                    iscorrectinglane = false;
                }
            }
            else if (transform.localPosition.x >= -0.5 && transform.localPosition.x <= 0.5 )
            {
                positionx = Mathf.Lerp(positionx, 0, sideMovement * Time.deltaTime);
                transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();

                if (transform.localPosition.x > -0.05 && transform.localPosition.x < 0.05)
                {
                    positionx = 0;
                    transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                    iscorrectinglane = false;
                }
            }
            else if (transform.localPosition.x > 0.5 )
            {
                positionx = Mathf.Lerp(positionx, 1, sideMovement * Time.deltaTime);
                transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                ChickPosRefer.GetComponent<ChickenPosUpdater>().UpdateChickenPosStarter();
                if (transform.localPosition.x > 0.97)
                {
                    positionx = 1;
                    transform.localPosition = new Vector3(positionx, transform.localPosition.y, 0);
                    iscorrectinglane = false;
                }

            }
        }



    }

  
}
