using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public bool isHit = false;
    Vector3 originalPosition;
    private void Start()
    {
        originalPosition = transform.position;
        PlayerAnimationManager.instance.Play_Idle();
    }
    private void Update()
    {
        if(!GameManager.Instance.isPlaying) return;
        CheckOutOfScreen();
        transform.position = new Vector3(transform.position.x, 1.5f,0);
        transform.rotation = Quaternion.Euler(0,0,0);

        if (!isHit) 
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, originalPosition, Time.deltaTime);
        }
    }

    void CheckOutOfScreen()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.x < -0.1f)
        {
            Debug.Log("GameObject is outside the top of the screen");
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.name == "Damage")
            {
                GameManager.Instance.GameOver();
                rb.constraints &= ~RigidbodyConstraints.FreezeRotation;
                rb.AddForce(new Vector3(100, 200, 300));
                Debug.Log("Damage");
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.name == "Obstacle")
            {
                isHit = true;
            }
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.name == "Obstacle")
            {
                isHit = false;
            }
        }
    }
}
