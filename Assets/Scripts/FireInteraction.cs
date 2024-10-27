using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent OnFireInteraction;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("FireInteraction"))
        {
            OnFireInteraction?.Invoke();
        }
    }
}
