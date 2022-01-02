using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform RotationObject;
    public Transform Estruturas;
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
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
            //_rotation.x = 30;
            // rotate
            //RotationObject.transform.Rotate(_rotation);
            RotationObject.transform.Rotate(_rotation, Space.World);
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
            Debug.Log("HIT");
            if (hitInfo.transform.gameObject == null)
            {
                Debug.Log("HIT!!");
                // rotating flag
                _isRotating = true;

                // store mouse
                _mouseReference = Input.mousePosition;
            }
        }
        else
        {
            Debug.Log("NOT HIT");
            // rotating flag
            _isRotating = true;

            // store mouse
            _mouseReference = Input.mousePosition;
        }

    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }
}
