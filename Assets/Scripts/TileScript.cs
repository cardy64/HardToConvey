using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    [Header("Settings")]
    public int levelWidth;
    public int levelHeight;

    [Header("Assets")]
    public Grid grid;
    public Tilemap tilemap;
    public Tile basicBlock;

    // Function for checking a tile
    TileBase CheckTileBase(int x, int y)
    {
        Vector3Int position = new(x, y, 0);
        return tilemap.GetTile(position);
    }

    // Function used for testing
    void SetTile(int x, int y, TileBase tileBase)
    {
        Vector3Int position = new(x, y, 0);
        tilemap.SetTile(position, tileBase);
    }

    void Update()
    {
        // Get the position of the mouse in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3Int cellPosition = tilemap.WorldToCell(new Vector3(mousePosition.x, mousePosition.y, 0f));
        // TileBase tileBase = CheckTileBase(cellPosition.x, cellPosition.y);

        if (Input.GetMouseButton(0)) {
            if (cellPosition.x >= 0 && cellPosition.x < levelWidth &&
                cellPosition.y >= 0 && cellPosition.y < levelHeight) {
                SetTile(cellPosition.x, cellPosition.y, basicBlock);
            }
        }

        // Input.GetMouseButtonDown(0) for click of left

        if (Input.GetMouseButton(1)) {
            SetTile(cellPosition.x, cellPosition.y, null);
        }
    }
}
