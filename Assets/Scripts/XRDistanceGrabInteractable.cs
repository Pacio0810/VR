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
        Vector3 differencePosition = rayInteractor.transform.position - transform.position;
        Vector3 differencePositionXZ = new Vector3(differencePosition.x, 0, differencePosition.z);
        float differencePositionXZLength = differencePositionXZ.magnitude;
        float differencePositionYLength = differencePosition.y;

        float angleInRadians = jumpAngleInDegree * Mathf.Deg2Rad;

        // Formula per calcolare la velocita' necessaria di un oggetto per raggiungere una determinata posizione (differencePosition) con un determinato angolo (AngleinDegree)
        float jumpSpeed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(differencePositionXZLength, 2) / 
                        (2 * Mathf.Cos(angleInRadians) * Mathf.Cos(angleInRadians) * (differencePositionXZLength * Mathf.Tan(angleInRadians) - differencePositionYLength)));
        
        Vector3 jumpVelocityVector = differencePositionXZ.normalized * Mathf.Cos(angleInRadians) * jumpSpeed + Vector3.up * Mathf.Sin(angleInRadians) * jumpSpeed;

        return jumpVelocityVector;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs Args)
    {
        if(Args.interactorObject is XRRayInteractor)
        {
            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;

            rayInteractor = (XRRayInteractor)Args.interactorObject;
            previousPosition = rayInteractor.transform.position;
            canJump = true;
        }
        else
        {
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = true;
        }

        base.OnSelectEntered(Args);
    }
}
