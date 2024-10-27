using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public Vector3 PositionTarget;
    public float Duration = 2.0f;
    public void Activate()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        float elapsedTime = 0;

        while (elapsedTime < Duration)
        {
            transform.position = Vector3.Lerp(transform.position, PositionTarget,  elapsedTime / Duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = PositionTarget;
    }
}
