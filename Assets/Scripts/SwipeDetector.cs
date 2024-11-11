using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float minDistanceForSwipe = 20f;

    private void Update()
    {
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        //foreach (Touch touch in Input.touches)
        //{
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        fingerDownPosition = touch.position;
        //        fingerUpPosition = touch.position;
        //    }
        //    if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
        //    {
        //        fingerUpPosition = touch.position;
        //        //CheckSwipe();
        //    }
        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        fingerUpPosition = touch.position;
        //        CheckSwipe();
        //    }
        //}
        if (Input.GetMouseButtonDown(0))
        {
            fingerDownPosition = Input.mousePosition;
            fingerUpPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            fingerUpPosition = Input.mousePosition;
            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (fingerDownPosition.x - fingerUpPosition.x > 0)
            {
                GetComponent<PlatformManager>().RotatePlatform(false);
                Debug.Log("Left Swipe");
            }
            else
            {
                GetComponent<PlatformManager>().RotatePlatform(true);
                Debug.Log("Right Swipe");
            }

            fingerDownPosition = fingerUpPosition;
        }
    }

    private bool SwipeDistanceCheckMet()
    {
        return Vector2.Distance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe;
    }
}
