using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{

    private bool moving = false;

    void Start()
    {
        Grid.Workers.Add(transform);
        moveDown();
    }

    void Update()
    {
        moveDown();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && isClicked(mousePos))
        {
            moving = true;
            if (isValidPos(mousePos))
            {
                transform.position = moveTo(mousePos);
                updateGrid();
            }
        }
        if (moving && Input.GetMouseButton(0))
        {
            if(isValidPos(mousePos))
            {
                transform.position = moveTo(mousePos);
                updateGrid();
            }
        }
        if (moving && Input.GetMouseButtonUp(0))
        {
            if (isValidPos(mousePos))
            {
                transform.position = moveTo(mousePos);
                updateGrid();
                moveDown();
            }
            moving = false;
        }
    }

    private bool isClicked(Vector3 mousePos)
    {
        Vector2 v1 = Grid.roundVec2(mousePos);
        Vector2 v2 = Grid.roundVec2(transform.position);
        if (v1.x == v2.x && v1.y == v2.y) return true;
        return false;
    }

    private Vector3 moveTo(Vector3 mousePosition)
    {
        Vector2 v = Grid.roundVec2(mousePosition);
        return new Vector3(v.x, v.y, 0);
    }

    private bool isValidPos(Vector3 mousePosition)
    {
        Vector2 v = Grid.roundVec2(mousePosition);
        if (!Grid.insideBorder(v)) return false;

        if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y] != transform) return false;

        return true;
    }

    private void moveDown()
    {
        while (true)
        {
            transform.position += new Vector3(0, -1, 0);
            if (isValidGridPos()) updateGrid();
            else
            {
                transform.position += new Vector3(0, 1, 0);
                break;
            }
        }
    }
    void updateGrid()
    {
        // Remove old
        for (int i = 0; i < Grid.Workers.Count; i++) if (Grid.Workers[i] == transform)
            {
                Vector2 v = Grid.roundVec2(transform.position);
                Grid.Workers[i] = transform;
            }
    }

    bool isValidGridPos()
    {
        Vector2 v = Grid.roundVec2(transform.position);
        if (!Grid.insideBorder(v)) return false;

        //if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y] != transform) return false;
        if (Grid.grid[(int)v.x, (int)v.y] != null) return false;

        foreach (Transform trans in Grid.Workers) if(trans != transform) if ((int)trans.position.x == (int)v.x && (int)trans.position.y == (int)v.y) return false;

        return true;
    }


}
