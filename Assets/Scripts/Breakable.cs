using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> BreakablesPieces;
    public float TimeToBreak = 1.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in BreakablesPieces)
        {
            item.SetActive(false);
        }
    }

    public void Breake()
    {
        timer += Time.deltaTime;
        if (timer > TimeToBreak)
        {
            foreach (var item in BreakablesPieces)
            {
                item.SetActive(true);
                item.transform.parent = null;
            }
            gameObject.SetActive(false);
        }
    }
}
