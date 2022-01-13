using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PerspectiveManager : MonoBehaviour
{
    public List<GameObject> Blocks = new List<GameObject>();
    public GameObject BallUp;
    public GameObject BallFront;
    public GameObject InitialBlock;
    public GameObject Slider;
    public void ChangePerspective()
    {
        DisableRigidbody();
        SetBall();
        Slider.SetActive(false);
    }
    public void SetBall()
    {
        BallFront.transform.position = InitialBlock.transform.position + new Vector3(0, .5f, 0);
        BallUp.SetActive(false);
        BallFront.SetActive(true);
    }
    public void DisableRigidbody()
    {
        foreach(GameObject block in Blocks)
        {
            block.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    public void SetBlocks(List<GameObject> _Blocks)
    {
        Blocks = _Blocks;
    }
}
