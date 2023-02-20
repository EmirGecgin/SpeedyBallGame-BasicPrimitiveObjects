using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 _offset;
    private Vector3 _newCameraPos;
    [SerializeField] private float lerpValue;

    private void Awake()
    {
        _offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        _newCameraPos = Vector3.Lerp(transform.position, playerTransform.position + _offset, lerpValue );
        transform.position = _newCameraPos;
    }
}
