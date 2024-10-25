using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireInteraction : MonoBehaviour
{
    BoxCollider BoxCollider;

    [SerializeField] UnityEvent OnFireInteraction;

    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireInteraction"))
        {
            OnFireInteraction?.Invoke();
        }
    }
}
