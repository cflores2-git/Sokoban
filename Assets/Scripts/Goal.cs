using UnityEngine;

public class Goal : MonoBehaviour
{
    public LayerMask boxesLayer;
    public bool IsFilled{get; private set;}
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        IsFilled = Physics2D.OverlapPoint(transform.position, boxesLayer) !=null;
    }
}
