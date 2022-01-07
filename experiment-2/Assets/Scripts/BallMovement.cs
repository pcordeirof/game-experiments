using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public Animator BallAnimator;
    public Transform BallTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {            
            BallAnimator.SetTrigger("Jump");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 force = new Vector3(1f, 0, 0);
            BallAnimator.SetBool("MovRight", true);
            BallTransform.position += force * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            BallAnimator.SetBool("MovRight", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 force = new Vector3(-1f, 0, 0);
            BallAnimator.SetBool("MovLeft", true);
            BallTransform.position += force * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            BallAnimator.SetBool("MovLeft", false);
        }

    }

    public void Jump()
    {
        BallRigidbody.AddRelativeForce(new Vector2(0, 5f), ForceMode2D.Impulse);
    }
}
