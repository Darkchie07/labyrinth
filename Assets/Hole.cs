using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{
    // public UnityEvent OnBallEnter = new UnityEvent();
    [SerializeField] private CustomEvent customevent;
    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            customevent.OnInvoked.Invoke();
        }
    }
}
