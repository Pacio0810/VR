using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChessInPosition : MonoBehaviour
{
    public string RequiredChessTag;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag(RequiredChessTag) && Other.transform.localScale.x >= 0.95f)
        {
            if (Other.GetComponent<XRGrabInteractable>().isSelected)
            {
                Other.GetComponent<XRGrabInteractable>().interactorsSelecting.Clear();
            }
            
            Other.GetComponent<Rigidbody>().useGravity = false;
            Other.transform.parent = transform;
            Other.transform.rotation = transform.rotation;
            Other.transform.position = transform.position;
            
            Other.GetComponent<XRGrabInteractable>().enabled = false;
            
            BoardChallengeManager.Instance.AddPieceInPosition();

            enabled = false;
        }
    }
}
