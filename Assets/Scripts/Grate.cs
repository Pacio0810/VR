using UnityEngine;

public class Grate : MonoBehaviour
{
    [Header("Open Grate")]
    public Vector3 grateRotation;
    public Vector3 Offset;

    public void Activate()
    {
        transform.localPosition += Offset;
        transform.localRotation = Quaternion.Euler(grateRotation);
    }
}
