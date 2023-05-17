using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float acceleration = 9.8f;
    private Quaternion gravityoffset = Quaternion.identity;
    private bool isActive = true;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        CalibrateGravity();
    }

    private void Update()
    {
        if (isActive)
        {
            Physics.gravity = gravityoffset * GetGravityfromSensor();
        }
        else
        {
            Physics.gravity = Vector3.zero;
        }
    }

    public void CalibrateGravity()
    {
        gravityoffset = Quaternion.FromToRotation(GetGravityfromSensor(), Vector3.down * acceleration);
    }

    public Vector3 GetGravityfromSensor()
    {
        Vector3 gravity;
        if (Input.gyro.gravity != Vector3.zero)
        {
            gravity = Input.gyro.gravity * acceleration;
        }
        else
        {
            gravity = Input.acceleration * acceleration;
        }

        gravity.z = Mathf.Clamp(gravity.z, float.MinValue, -1);
        return new Vector3(gravity.x, gravity.z, gravity.y);
    }

    public void SetActive(bool value)
    {
        isActive = value;
        if (value)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
