using UnityEngine;
using UnityEngine.Events;

public class BoardChallengeManager : MonoBehaviour
{
    [Header("Second Challenge Settings")]
    public int PieceToPlace = 4;
    public int PieceInPosition = 0;
    [SerializeField] private UnityEvent SecondChallengeCompletedEvent;
    
    public static BoardChallengeManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public void AddPieceInPosition()
    {
        PieceInPosition++;
        CheckAllPiecesInPosition();
    }

    public void RemovePieceInPosition()
    {
        PieceInPosition--;
    }

    private void CheckAllPiecesInPosition()
    {
        if (PieceInPosition == PieceToPlace)
        {
            SecondChallengeCompletedEvent?.Invoke();
        }
    }
}
