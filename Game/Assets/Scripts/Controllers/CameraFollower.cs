﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        Vector3 endPos = targetTransform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, endPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
