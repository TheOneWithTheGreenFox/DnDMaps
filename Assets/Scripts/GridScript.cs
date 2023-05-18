using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public float xStart;
    public float xEnd;
    public float yStart;
    public float yEnd;

    public GameObject gridSquare;

    void Start()
    {
        MakeGrid();
    }

    private void MakeGrid()
    {
        for(float x = xStart; x < xEnd; x++)
        {
            for (float y = yStart; y < yEnd; y++)
            {
                Instantiate(gridSquare, new Vector3(x, y, 0), Quaternion.identity, gameObject.transform);
            }
        }
    }
}
