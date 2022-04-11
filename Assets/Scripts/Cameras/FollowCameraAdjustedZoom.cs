using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraAdjustedZoom : MonoBehaviour
{
    public bool adjustZoom = false;
    public GameObject Followcam;
    public GameObject chickenPosRef;
    public float camoffset;
    private Cinemachine.CinemachineTransposer TransposerRef;
    private Cinemachine.CinemachineComposer ComposerRef;
    private List<Transform> ActualChicksListref;

    private void Awake()
    {
        TransposerRef = Followcam.GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineTransposer>();
        ComposerRef = Followcam.GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineComposer>();
        ActualChicksListref = chickenPosRef.GetComponent<ChickenPosUpdater>().actualChicksList;
    }

    void Update()
    {
        if (adjustZoom)
        {
            TransposerRef.m_FollowOffset.z = -2.25f - (camoffset * ActualChicksListref.Count);
            ComposerRef.m_TrackedObjectOffset.y = 0.75f - (2*camoffset * ActualChicksListref.Count);
        }
    }
}
