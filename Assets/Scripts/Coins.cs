using UnityEngine;

public class Coins : MonoBehaviour
{
    public Transform player;
    public bool collected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            return;
        }

        if (Vector2.Distance(player.position, transform.position)<0.1f)
        {
            collected = true;
            gameObject.SetActive(false);
        }
    }
}
