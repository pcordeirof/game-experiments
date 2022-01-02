using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TRIGGER");
        Destroy(other.gameObject);
    }
}
