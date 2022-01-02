using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotation : MonoBehaviour
{
    public Transform BaseTransform;
    public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        BaseTransform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }
}
