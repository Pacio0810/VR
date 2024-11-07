using UnityEngine;

public class ChessInPosition : MonoBehaviour
{
    public string RequiredChessTag;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag(RequiredChessTag))
        {
            BoardChallengeManager.Instance.AddPieceInPosition();
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag(RequiredChessTag))
        {
            BoardChallengeManager.Instance.RemovePieceInPosition();
        }
    }
}
