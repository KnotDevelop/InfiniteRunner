using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Player player; // The target to follow
    //public PlatformManager platformManager;
    //public float smoothSpeed = 0.125f; // The smoothness of the camera movement
    //public Vector3 offset; // The offset from the target's position

    //public bool isReseting = false;
    //public float count = 0;

    //void LateUpdate()
    //{
        //if (!GameManager.Instance.isPlaying) return;
        //if (isReseting)
        //{
        //    count += Time.deltaTime;
        //    if (count >= 0.1f)
        //    {
        //        smoothSpeed += Time.deltaTime;
        //        if (smoothSpeed >= 1)
        //        {
        //            isReseting = false;
        //            smoothSpeed = 1;
        //        }
        //    }
        //}

        //if (!player.isHit)
        //{
            //Vector3 desiredPosition = player.transform.position + offset;
            //desiredPosition.y = transform.position.y;
            //desiredPosition.z = transform.position.z;
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            //transform.position = smoothedPosition;
        //}
        //else
        //{
            //smoothSpeed = 0.001f;
            //count = 0;
            //isReseting = true;
            //Vector3 desiredPosition = player.transform.position + offset;
            //desiredPosition.y = transform.position.y;
            //desiredPosition.z = transform.position.z;
            //transform.position += new Vector3(-platformManager.speed / 2.5f * Time.deltaTime, 0, 0);
        //}
    //}
}
