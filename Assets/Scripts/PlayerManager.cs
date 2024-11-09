using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnSceneLoaded(Transform SpawnTransform)
    {
        transform.position = SpawnTransform.position;
        transform.rotation = SpawnTransform.rotation;
    }
}
