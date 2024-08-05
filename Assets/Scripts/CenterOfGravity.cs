using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfGravity : MonoBehaviour
{
    public Vector3 CenterOfMass;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = CenterOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        _rb.centerOfMass = CenterOfMass;
        _rb.WakeUp();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + transform.rotation * CenterOfMass, 0.05f);
    }
}
