using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckersBoardManager : MonoBehaviour
{
    public Tilemap boardTilemap; // Unity Editor üzerinden atayýn
    public GameObject piecePrefab; // Taþ prefab'ý, Unity Editor üzerinden atayýn

    private Dictionary<Vector2Int, GameObject> pieceObjects = new Dictionary<Vector2Int, GameObject>();
    private bool isPlayerTurn = true;
    private Vector2Int? selectedPiecePosition = null;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        // Oyun baþlangýcýnda taþlarýn yerleþtirilmesi
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if ((i + j) % 2 != 0)
                {
                    CreatePiece(new Vector2Int(i, j), true); // Oyuncu taþlarý
                }
            }

            for (int j = 5; j < 8; j++)
            {
                if ((i + j) % 2 != 0)
                {
                    CreatePiece(new Vector2Int(i, j), false); // Bot taþlarý
                }
            }
        }

        isPlayerTurn = true;
    }

    void Update()
    {
        if (isPlayerTurn)
        {
            HandlePlayerInput();
        }
        // Bot'un hamlesi baþka bir metodda ele alýnabilir
    }

    void HandlePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = boardTilemap.WorldToCell(worldPosition);
            Vector2Int gridPosition = new Vector2Int(cellPosition.x, cellPosition.y);

            if (!selectedPiecePosition.HasValue)
            {
                // Eðer bir taþ seçiliyse ve taþ mevcutsa
                if (pieceObjects.ContainsKey(gridPosition))
                {
                    selectedPiecePosition = gridPosition;
                }
            }
            else
            {
                // Taþý yeni konuma taþý
                MovePiece(selectedPiecePosition.Value, gridPosition);
                selectedPiecePosition = null; // Seçimi sýfýrla
                isPlayerTurn = false; // Sýrayý bota geçir
            }
        }
    }

    void CreatePiece(Vector2Int position, bool isPlayerPiece)
    {
        var pieceObject = Instantiate(piecePrefab, boardTilemap.GetCellCenterWorld(new Vector3Int(position.x, position.y, 0)), Quaternion.identity);
        pieceObjects.Add(position, pieceObject);

        // Burada isPlayerPiece'e baðlý olarak taþýn rengini ayarlayabilirsiniz
    }

    void MovePiece(Vector2Int oldPosition, Vector2Int newPosition)
    {
        if (pieceObjects.TryGetValue(oldPosition, out var pieceObject))
        {
            pieceObjects.Remove(oldPosition);
            pieceObjects[newPosition] = pieceObject;
            pieceObject.transform.position = boardTilemap.GetCellCenterWorld(new Vector3Int(newPosition.x, newPosition.y, 0));

            // Tahtayý güncelle veya gerekiyorsa ek kurallarý burada kontrol et
        }
    }
}
