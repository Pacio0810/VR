using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class ShowTXT : MonoBehaviour
{
    [SerializeField]
    TextMeshPro TextMesh;

    private void Start()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        Debug.Log("Collidere Size: " + boxCollider.bounds.size.magnitude);
    }

    void Update()
    {
        TextMesh.text = transform.localScale.x.ToString("F2");
    }


}
