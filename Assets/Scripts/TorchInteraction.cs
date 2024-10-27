using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TorchInteraction : MonoBehaviour
{
    [Header("Fire Settings")]
    [SerializeField] private GameObject fireObject;
    public float ActiveFireTimer = 45.0f;
    public bool CanBeDisable = true;

    [SerializeField] private UnityEvent OnFireInteraction;
    [SerializeField] private UnityEvent FireOffEvent;
    
    private float currentFireTime;
    private BoxCollider boxCollider;
    
    public void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        
        currentFireTime = ActiveFireTimer;
    }

    private void OnTriggerEnter(Collider Other)
    {
        boxCollider.enabled = false;
        if (Other.gameObject.CompareTag("FireInteraction"))
        {
            OnFireInteraction?.Invoke();
        }
    }

    public void ActiveFire()
    {
        if (fireObject.activeInHierarchy)
        {
            ResetFireTimer();
        }

        fireObject?.SetActive(true);
    }

    private void Update()
    {
        if (fireObject.activeInHierarchy && CanBeDisable)
        {
            currentFireTime -= Time.deltaTime;

            if (currentFireTime < 0)
            {
                boxCollider.enabled = true;
                DeactivateFire();
            }
        }
    }

    void ResetFireTimer()
    {
        currentFireTime = ActiveFireTimer;
    }
    void DeactivateFire()
    {
        fireObject?.SetActive(false);
        FireOffEvent?.Invoke();
        ResetFireTimer();
    }

}
