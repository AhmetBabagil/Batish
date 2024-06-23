using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckersBoard : MonoBehaviour
{
    public Tilemap tilemap;

    public TileBase blackTile;
    public TileBase whiteTile;
    public GameObject blackCheckerPrefab; // Siyah ta� prefab'�
    public GameObject whiteCheckerPrefab; // Beyaz ta� prefab'�

    private void Start()
    {
        GenerateBoard();
        PlaceCheckers();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                var tile = (x + y) % 2 == 0 ? whiteTile : blackTile;
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    void PlaceCheckers()
    {
        // Oyuncular�n ta�lar�n� yerle�tir
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 3; y++) // Beyaz ta�lar i�in �st 3 sat�r
            {
                if ((x + y) % 2 != 0) // Sadece siyah kareler
                {
                    Instantiate(whiteCheckerPrefab, tilemap.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                }
            }

            for (int y = 5; y < 8; y++) // Siyah ta�lar i�in alt 3 sat�r
            {
                if ((x + y) % 2 != 0) // Sadece siyah kareler
                {
                    Instantiate(blackCheckerPrefab, tilemap.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                }
            }
        }
    }
}
