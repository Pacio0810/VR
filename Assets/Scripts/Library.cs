using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    [Header("Activate Settings")]
    public Vector3 PositionTarget;
    public float Duration = 5.0f;
    public float MovementSpeed = 2.0f;

    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    public void Activate()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        float elapsedTime = 0;

        while (elapsedTime < Duration)
        {
            transform.position = Vector3.Lerp(transform.position, PositionTarget,  Time.deltaTime * MovementSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        gameObject.SetActive(true);
        transform.position = PositionTarget;
    }
}
