using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteraction : MonoBehaviour
{
    [Header("Fire Settings")]
    [SerializeField]GameObject FireObject;
    public float ActiveFireTimer = 45.0f;

    float CurrentFireTime;

    public void Start()
    {
        CurrentFireTime = ActiveFireTimer;
    }

    public void ActiveFire()
    {
        if (FireObject.activeInHierarchy)
        {
            ResetFireTimer();
        }

        FireObject?.SetActive(true);
    }

    private void Update()
    {
        if (FireObject.activeInHierarchy)
        {
            CurrentFireTime -= Time.deltaTime;

            if (CurrentFireTime < 0)
            {
                DeactivateFire();
            }
        }
    }

    public void ResetFireTimer()
    {
        CurrentFireTime = ActiveFireTimer;
    }

    public void DeactivateFire()
    {
        FireObject?.SetActive(false);
    }

}
