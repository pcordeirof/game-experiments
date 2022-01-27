using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallFrontMovement : MonoBehaviour
{
    public Rigidbody2D BallRigidbody;
    public Animator BallAnimator;
    public Transform BallTransform;

    public float jumpForce;

    public bool isGrounded = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        else if(collision.gameObject.tag == "Final")
        {            
            isGrounded = false;
            SceneManager.LoadScene("Gameplay");
        }
        else
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        BallRigidbody.AddRelativeForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }
}
