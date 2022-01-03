using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTrigger : MonoBehaviour
{
    public Light Light;
    Color DefautColor;
    public AudioSource audioSource;
    public AudioClip pointSFX;
    void Awake()
    {
        DefautColor = Light.color;
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        StartCoroutine(ChangeColorLight());
    }

    public IEnumerator ChangeColorLight()
    {
        Light.color = new Color(31f, 180f, 245f);
        Light.intensity = 10f;
        Light.range = .8f;
        audioSource.PlayOneShot(pointSFX);
        yield return new WaitForSeconds(0.5f);
        Light.color = DefautColor;
        Light.intensity = 20f;
        Light.range = 10f;
    } 
}
