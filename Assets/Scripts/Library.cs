using System.Collections;
using UnityEngine;

public class Library : MonoBehaviour
{
    [Header("Activate Settings")]
    public Vector3 PositionTarget;
    public float Duration = 5.0f;
    public float MovementSpeed = 2.0f;
    
    [Header("Books in Library")]
    [SerializeField]private GameObject[] books;
    
    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    IEnumerator MoveCoroutine()
    {
        float elapsedTime = 0;
        
        while (elapsedTime < Duration)
        {
            transform.position = Vector3.Lerp(transform.position, PositionTarget,  Time.deltaTime * MovementSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = PositionTarget;
        
        foreach (GameObject book in books)
        {
            book.GetComponentInChildren<BoxCollider>().enabled = true;
            book.GetComponentInChildren<Rigidbody>().useGravity = true;
        }

        books = null; // imposto l'array a null per liberare memoria
    }
}
