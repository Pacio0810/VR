using UnityEngine;

public class ActiveBoardLight : MonoBehaviour
{
    public GameObject LightToActive;
    private void OnTriggerEnter(Collider Other)
    {
        if (!Other.CompareTag("Player") || LightToActive.activeInHierarchy)
        {
            return;
        }
        
        LightToActive.SetActive(true);
        Destroy(gameObject);
    }
}
