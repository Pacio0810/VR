using UnityEngine;

public class ChessInPosition : MonoBehaviour
{
    public string RequiredChessTag;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag(RequiredChessTag) && Other.transform.localScale.x.Equals(1f))
        {
            BoardChallengeManager.Instance.AddPieceInPosition();
            Debug.Log(BoardChallengeManager.Instance.PieceInPosition);
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag(RequiredChessTag))
        {
            BoardChallengeManager.Instance.RemovePieceInPosition();
            Debug.Log(BoardChallengeManager.Instance.PieceInPosition);
        }
    }
}
