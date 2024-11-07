using UnityEngine;
using UnityEngine.Events;

public class TorchInteraction : MonoBehaviour
{
    [Header("Fire Settings")]
    [SerializeField] private GameObject fireObject;
    public float ActiveFireTimer = 45.0f;
        
    [Header("Torch Fire Event")]
    [SerializeField] private UnityEvent OnFireInteraction;
    [SerializeField] private UnityEvent FireOffEvent;
    
    private float currentFireTime;
    private BoxCollider boxCollider;
    
    public void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        ResetFireTimer();
    }

    public void SetActiveFireTimer(float NewFireTimer)
    {
        ActiveFireTimer = NewFireTimer;
        ResetFireTimer();
    }
    
    private void OnTriggerEnter(Collider Other)
    {
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
        
        if (Other.gameObject.CompareTag("FireInteraction"))
        {
            OnFireInteraction?.Invoke();
        }
    }

    public void ActiveFire()
    {
        if (fireObject.activeInHierarchy)
        {
            ResetFireTimer();
        }

        fireObject?.SetActive(true);
    }

    private void Update()
    {
        if (fireObject.activeInHierarchy)
        {
            currentFireTime -= Time.deltaTime;

            if (currentFireTime < 0)
            {
                boxCollider.enabled = true;
                DeactivateFire();
            }
        }
    }

    void ResetFireTimer()
    {
        currentFireTime = ActiveFireTimer;
    }
    void DeactivateFire()
    {
        fireObject?.SetActive(false);
        FireOffEvent?.Invoke();
        ResetFireTimer();
    }
}