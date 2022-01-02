using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public Transform RotationObject;
    public Renderer ObjectRenderer;
    public Material DefautMaterial;
    public Material SelectMaterial;
    private float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;

    void Start()
    {
        _sensitivity = 0.4f;
        _rotation = Vector3.zero;
    }

    void Update()
    {
        
        if (_isRotating)
        {
            ObjectRenderer.material = SelectMaterial;
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

            // rotate
            RotationObject.transform.Rotate(_rotation);

            // store mouse
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
       
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        if (hit)
        {
            if(hitInfo.transform.gameObject == this.gameObject)
            {
                Debug.Log("HIT!!");
                // rotating flag
                _isRotating = true;

                // store mouse
                _mouseReference = Input.mousePosition;
            }
        }
        
    }

    void OnMouseUp()
    {
        ObjectRenderer.material = DefautMaterial;
        // rotating flag
        _isRotating = false;
    }

}
