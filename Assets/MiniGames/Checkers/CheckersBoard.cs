using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckersBoard : MonoBehaviour
{
    public Tilemap tilemap;

    public TileBase blackTile;
    public TileBase whiteTile;
    public GameObject blackCheckerPrefab; // Siyah taþ prefab'ý
    public GameObject whiteCheckerPrefab; // Beyaz taþ prefab'ý

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
        // Oyuncularýn taþlarýný yerleþtir
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 3; y++) // Beyaz taþlar için üst 3 satýr
            {
                if ((x + y) % 2 != 0) // Sadece siyah kareler
                {
                    Instantiate(whiteCheckerPrefab, tilemap.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                }
            }

            for (int y = 5; y < 8; y++) // Siyah taþlar için alt 3 satýr
            {
                if ((x + y) % 2 != 0) // Sadece siyah kareler
                {
                    Instantiate(blackCheckerPrefab, tilemap.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                }
            }
        }
    }
}
