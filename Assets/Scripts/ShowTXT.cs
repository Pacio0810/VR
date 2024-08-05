using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class ShowTXT : MonoBehaviour
{
    [SerializeField]
    TextMeshPro TextMesh;

    void Update()
    {
        TextMesh.text = transform.localScale.x.ToString("F2");
    }
}
