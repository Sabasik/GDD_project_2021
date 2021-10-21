using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private float fallTime = 0;
    public float fallSpeed = 1f;


    void Start()
    {
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            updateGrid();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidGridPos()) updateGrid();
            else transform.position += new Vector3(1, 0, 0);
        }
        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (isValidGridPos()) updateGrid();
            else transform.position += new Vector3(-1, 0, 0);
        }
        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, -90);
            if (isValidGridPos()) updateGrid();
            else transform.Rotate(0, 0, 90);
        }
        // Move Down
        else if (Time.time - fallTime >= fallSpeed || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0);
            if (isValidGridPos()) updateGrid(); 
            else
            {
                transform.position += new Vector3(0, 1, 0);
                Grid.deleteFullRows();
                FindObjectOfType<Spawner>().spawnNext();
                enabled = false;
            }
            fallTime = Time.time;
        }
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            if (!Grid.insideBorder(v)) return false;

            if (Grid.grid[(int)v.x, (int)v.y] != null) {
                // Worker
                if (Grid.grid[(int)v.x, (int)v.y].GetComponent<Worker>() != null)
                {
                    print("Worker hit");
                    Destroy(Grid.grid[(int)v.x, (int)v.y].gameObject);
                    Grid.grid[(int)v.x, (int)v.y] = null;
                    // TODO: when worker is hit
                    return true;
                }
                // Something else
                if (Grid.grid[(int)v.x, (int)v.y].parent != transform) return false;
            }
        }
        return true;
    }

    void updateGrid()
    {
        // Remove old
        for (int y = 0; y < Grid.h; ++y) for (int x = 0; x < Grid.w; ++x) if (Grid.grid[x, y] != null) if (Grid.grid[x, y].parent == transform) Grid.grid[x, y] = null;

        // Add new
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
