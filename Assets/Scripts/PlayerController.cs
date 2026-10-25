using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Tilemap floor;
    public Tilemap walls;
    public LayerMask boxesLayer;
    public int moves;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = floor.GetCellCenterWorld(floor.WorldToCell(transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMoveUp(InputValue value)
    {
        if (value.isPressed)
        {
                TryMove(Vector3.up);
        }
    }

    public void OnMoveDown(InputValue value)
    {
        if (value.isPressed)
        {
                TryMove(Vector3.down);
        }
    }

    public void OnMoveLeft(InputValue value)
    {
        if (value.isPressed)
        {
                TryMove(Vector3.left);
        }
    }

    public void OnMoveRight(InputValue value)
    {
        if (value.isPressed)
        {
            TryMove(Vector3.right);
        }
    }

    public void OnRestart(InputValue value)
    {
        if (value.isPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    bool IsOpen(Vector3 position)
    {
        return floor.HasTile(floor.WorldToCell(position))&&!walls.HasTile(walls.WorldToCell(position));
    }

    void TryMove(Vector3 direction)
    {
        Vector3 destination = transform.position + direction;

        if (!IsOpen(destination))
        {
            return;
        }
        Collider2D box = Physics2D.OverlapPoint(destination, boxesLayer);
        if(box!=null)
        {
            Vector3 boxDestination = destination + direction;
            if(!IsOpen(boxDestination)||Physics2D.OverlapPoint(boxDestination, boxesLayer)!=null)
            {
                return;
            }
            box.transform.position = boxDestination;
    }

    
        transform.position = destination;
        moves++;
        Physics2D.SyncTransforms();
    }


}
