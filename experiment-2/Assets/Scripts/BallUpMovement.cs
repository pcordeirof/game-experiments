using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUpMovement : MonoBehaviour
{
    public Transform BallTransform;
    public Animator BallAnimator;
    public float Speed;
    Vector3 position;
    float pushOffset = 0.01f;
    GameObject TouchedObject;

    void Update()
    {
        position = Vector3.zero;

        GetArrowsDown();
        GetArrowsUp();

        if(position != Vector3.zero)
        {
            BallAnimator.SetBool("Mov", true);
        }
        else
        {
            BallAnimator.SetBool("Mov", false);
        }

        if(BallAnimator.GetBool("Push") == true)
        {
            BallAnimator.SetFloat("X", position.x);
            BallAnimator.SetFloat("Y", position.y);
        }

        BallTransform.position += position;
    }

    public void GetArrowsDown()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {            
            position.x += Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y += Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            position.y -= Speed * Time.deltaTime;
        }
    }

    public void GetArrowsUp()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if(BallAnimator.GetBool("Push") == true)
            {
                TouchedObject.transform.position += Vector3.right * pushOffset;
            }
            BallAnimator.SetBool("Push", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (BallAnimator.GetBool("Push") == true)
            {
                TouchedObject.transform.position += Vector3.right * -pushOffset;
            }
            BallAnimator.SetBool("Push", false); ;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (BallAnimator.GetBool("Push") == true)
            {
                TouchedObject.transform.position += Vector3.up * pushOffset;
            }
            BallAnimator.SetBool("Push", false);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if(BallAnimator.GetBool("Push") == true)
            {
                TouchedObject.transform.position += Vector3.up * -pushOffset;
            }
            BallAnimator.SetBool("Push", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            TouchedObject = collision.gameObject;
            BallAnimator.SetBool("Push", true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            TouchedObject = collision.gameObject;
            BallAnimator.SetBool("Push", true);
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
    }*/
}
