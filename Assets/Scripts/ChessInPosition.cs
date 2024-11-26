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
            
            // Disabilito il Rigidbody
            Other.GetComponent<Rigidbody>().detectCollisions = false;
            Other.GetComponent<Rigidbody>().isKinematic = true;

            // Setto il parent, la sua posizione e rotazione
            Other.transform.parent = transform;
            Other.transform.rotation = transform.rotation;
            Other.transform.position = transform.position;
            
            // Disabilito il GrabComponent, il box collider e aggiungo il pezzo al counter dei pezzi in posizione nel manager
            Other.GetComponent<XRGrabInteractable>().enabled = false;
            BoardChallengeManager.Instance.AddPieceInPosition();
            GetComponent<BoxCollider>().enabled = false;
            
        }
    }
}
