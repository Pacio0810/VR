using UnityEngine;

public class Grate : MonoBehaviour
{
    [Header("Open Grate")]
    public Vector3 grateRotation;
    public Vector3 Offset;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        transform.position += Offset;
        transform.rotation = Quaternion.Euler(grateRotation);
        _rigidbody.useGravity = true;
    }
}