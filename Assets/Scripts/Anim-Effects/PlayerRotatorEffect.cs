using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotatorEffect : MonoBehaviour
{
    public float rotationy, rotateSpeed;

    public void RightMovementEffect()
    {
        rotationy = Mathf.Clamp(rotationy + rotateSpeed, -20, +20);
        transform.localRotation = Quaternion.Euler(0, rotationy, 0);
        if (rotationy==20)
        {
            StopCoroutine(RotationResetCouroutine());
        }
    }

    public void LeftMovementEffect()
    {
        rotationy = Mathf.Clamp(rotationy - rotateSpeed, -20, +20);
        transform.localRotation = Quaternion.Euler(0, rotationy, 0);
        if (rotationy==-20)
        {
            StopCoroutine(RotationResetCouroutine());
        }
    }

    public IEnumerator RotationResetCouroutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            rotationy = Mathf.Lerp(rotationy, 0, rotateSpeed);
            transform.localRotation = Quaternion.Euler(0, 0, rotationy);
            if (rotationy <= 0.2 && rotationy >= -0.2)
            {
                rotationy = 0;
                transform.localRotation = Quaternion.Euler(0, 0, rotationy);
                break;
            }
        }


    }



}
