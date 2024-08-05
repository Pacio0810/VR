using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class SpaceOutsideController : MonoBehaviour
{
    public XRLever Lever;
    public XRKnob Knob;

    public float ForwardSpeed;
    public float SideSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ForwardVelocity = ForwardSpeed * (Lever.value ? 1 : 0);
        float SideVelocity = SideSpeed * (Lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, Knob.value);

        Vector3 Velocity = new Vector3(SideVelocity, 0, ForwardVelocity);
        transform.position += Velocity * Time.deltaTime;
    }
}
