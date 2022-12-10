using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform m_targetTransform;
    [SerializeField] private float m_lerpValue;
    [SerializeField] private Vector3 transformOffset;
    private Vector3 _targetTransform;


    private void Start()
    {
        transformOffset = transform.position;
    }

    private void LateUpdate()
    {
        _targetTransform = m_targetTransform.position + transformOffset;
        transform.position = Vector3.Lerp(transform.position, _targetTransform, Time.deltaTime * m_lerpValue);
    }
    
}