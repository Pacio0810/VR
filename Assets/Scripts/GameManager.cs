using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Manager;

    public static GameManager instance { get; private set; }

    public void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(Manager);
    }
}
