using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckersBoardManager : MonoBehaviour
{
    public Tilemap boardTilemap; // Unity Editor �zerinden atay�n
    public GameObject piecePrefab; // Ta� prefab'�, Unity Editor �zerinden atay�n

    private Dictionary<Vector2Int, GameObject> pieceObjects = new Dictionary<Vector2Int, GameObject>();
    private bool isPlayerTurn = true;
    private Vector2Int? selectedPiecePosition = null;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        // Oyun ba�lang�c�nda ta�lar�n yerle�tirilmesi
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if ((i + j) % 2 != 0)
                {
                    CreatePiece(new Vector2Int(i, j), true); // Oyuncu ta�lar�
                }
            }

            for (int j = 5; j < 8; j++)
            {
                if ((i + j) % 2 != 0)
                {
                    CreatePiece(new Vector2Int(i, j), false); // Bot ta�lar�
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
        // Bot'un hamlesi ba�ka bir metodda ele al�nabilir
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
                // E�er bir ta� se�iliyse ve ta� mevcutsa
                if (pieceObjects.ContainsKey(gridPosition))
                {
                    selectedPiecePosition = gridPosition;
                }
            }
            else
            {
                // Ta�� yeni konuma ta��
                MovePiece(selectedPiecePosition.Value, gridPosition);
                selectedPiecePosition = null; // Se�imi s�f�rla
                isPlayerTurn = false; // S�ray� bota ge�ir
            }
        }
    }

    void CreatePiece(Vector2Int position, bool isPlayerPiece)
    {
        var pieceObject = Instantiate(piecePrefab, boardTilemap.GetCellCenterWorld(new Vector3Int(position.x, position.y, 0)), Quaternion.identity);
        pieceObjects.Add(position, pieceObject);

        // Burada isPlayerPiece'e ba�l� olarak ta��n rengini ayarlayabilirsiniz
    }

    void MovePiece(Vector2Int oldPosition, Vector2Int newPosition)
    {
        if (pieceObjects.TryGetValue(oldPosition, out var pieceObject))
        {
            pieceObjects.Remove(oldPosition);
            pieceObjects[newPosition] = pieceObject;
            pieceObject.transform.position = boardTilemap.GetCellCenterWorld(new Vector3Int(newPosition.x, newPosition.y, 0));

            // Tahtay� g�ncelle veya gerekiyorsa ek kurallar� burada kontrol et
        }
    }
}
