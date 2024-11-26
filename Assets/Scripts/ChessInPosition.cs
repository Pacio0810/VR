using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChessInPosition : MonoBehaviour
{
    public string RequiredChessTag;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag(RequiredChessTag) && Other.transform.localScale.x.Equals(1f))
        {
            if (Other.GetComponent<XRGrabInteractable>().isSelected)
            {
                Other.GetComponent<XRGrabInteractable>().interactorsSelecting.Clear();
            }
            
            Other.transform.parent = transform;
            Other.transform.rotation = transform.rotation;
            Other.transform.position = transform.position;
            
            Other.GetComponent<XRGrabInteractable>().enabled = false;
            
            BoardChallengeManager.Instance.AddPieceInPosition();

            enabled = false;
        }
    }

    // private void OnTriggerExit(Collider Other)
    // {
    //     if (Other.CompareTag(RequiredChessTag))
    //     {
    //         BoardChallengeManager.Instance.RemovePieceInPosition();
    //         Debug.Log(BoardChallengeManager.Instance.PieceInPosition);
    //     }
    // }
}
