using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Rigidbody BallRigidbody;
    public float ForceAmountUp;

    public ForceAmount forceAmount;
    float ForceAmountX;
    float ForceAmountZ;


    public void Start()
    {
        ForceAmountX = forceAmount.XandZAmount.x;
        ForceAmountZ = forceAmount.XandZAmount.y;
        BallRigidbody.AddForce(new Vector3(ForceAmountX, ForceAmountUp, ForceAmountZ), ForceMode.Impulse);
    }

    private void Update()
    {
        if(this.gameObject.transform.position.y <= -40)
        {
            Destroy(this.gameObject);
        }
    }
}
