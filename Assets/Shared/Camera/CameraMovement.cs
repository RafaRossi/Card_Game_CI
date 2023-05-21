using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [Header("Pan Properties")]
    [SerializeField] private Vector2 panXLimits;
    [SerializeField] private Vector2 panZLimits;
    [SerializeField] private float panSpeed;
    private Vector3 _lastInput = Vector3.zero;

    [Header("Zoom Properties")]
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    [SerializeField] private float scrollSensitivity;

    [SerializeField] private float smoothTime;

    private Vector3 desiredPosition;
    
    private void LateUpdate()
    {
        //transform.position += transform.forward * (Input.mouseScrollDelta.y * scrollSensitivity);

        if(EventSystem.current.IsPointerOverGameObject()) return;
        
        Vector3 newPosition = transform.position - Vector3.up * Input.mouseScrollDelta.y;
        desiredPosition = Vector3.Lerp(transform.position, newPosition, scrollSensitivity * Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0))
        {
            _lastInput = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _lastInput;
            
            desiredPosition = MoveCamera(delta.x, delta.y);

            _lastInput = Input.mousePosition;
        }

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, panXLimits.x, panXLimits.y);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minZoom, maxZoom);
        desiredPosition.z = Mathf.Clamp(desiredPosition.z, panZLimits.x, panZLimits.y);

        //desiredPosition.y = Mathf.Lerp(transform.position.y, desiredPosition.y, smoothTime);
        
        transform.position = desiredPosition;
        //transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothTime);
    }

    private Vector3 MoveCamera(float x, float z)
    {
        float zMove = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180) * z - Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) * x;
        float xMove = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) * z + Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180) * x;
 
        return desiredPosition + new Vector3(xMove, 0, zMove) * (panSpeed * Time.deltaTime);

        /*desiredPosition.x = Mathf.Clamp(desiredPosition.x, panXLimits.x, panXLimits.y);
        desiredPosition.z = Mathf.Clamp(desiredPosition.z, panZLimits.x, panZLimits.y);*/
    }
}
