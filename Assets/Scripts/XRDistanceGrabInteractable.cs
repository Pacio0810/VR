using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRDistanceGrabInteractable : XRGrabInteractable
{
    public float VelocityThreshold = 2;
    public float jumpAngleInDegree = 60; 

    private XRRayInteractor rayInteractor;
    private Vector3 previousPosition;
    private Rigidbody interactableRigidBody;

    private bool canJump = true;

    protected override void Awake()
    {
        base.Awake();
        interactableRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isSelected && firstInteractorSelecting is XRRayInteractor && canJump)
        {
            Vector3 velocity = (rayInteractor.transform.position - previousPosition) / Time.deltaTime;
            previousPosition = rayInteractor.transform.position;

            if (velocity.magnitude > VelocityThreshold)
            {
                Drop();
                interactableRigidBody.velocity = ComputeVelocity();
                canJump = false;
            }
        }
    }

    public Vector3 ComputeVelocity()
    {
        Vector3 DifferencePosition = rayInteractor.transform.position - transform.position;
        Vector3 DifferencePositionXZ = new Vector3(DifferencePosition.x, 0, DifferencePosition.z);
        float DifferencePositionXZLength = DifferencePositionXZ.magnitude;
        float DifferencePositionYLength = DifferencePosition.y;

        float AngleInRadians = jumpAngleInDegree * Mathf.Deg2Rad;

        // Formula per calcolare la velocita' necessaria di un oggetto per raggiungere una determinata posizione (differencePosition) con un determinato angolo (AngleinDegree)
        float jumpSpeed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(DifferencePositionXZLength, 2) / 
                        (2 * Mathf.Cos(AngleInRadians) * Mathf.Cos(AngleInRadians) * (DifferencePositionXZLength * Mathf.Tan(AngleInRadians) - DifferencePositionYLength)));
        
        Vector3 JumpVelocityVector = DifferencePositionXZ.normalized * Mathf.Cos(AngleInRadians) * jumpSpeed + Vector3.up * Mathf.Sin(AngleInRadians) * jumpSpeed;

        return JumpVelocityVector;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject is XRRayInteractor)
        {
            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;

            rayInteractor = (XRRayInteractor)args.interactorObject;
            previousPosition = rayInteractor.transform.position;
            canJump = true;
        }
        else
        {
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = true;
        }

        base.OnSelectEntered(args);
    }
}
