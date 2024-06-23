using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TetrisBoard : MonoBehaviour
{

    private int score = 0; // Skor de�i�keni
    public TextMeshProUGUI scoreText; // Skoru g�sterecek UI elementi
    public TextMeshProUGUI highscoreText;
    [SerializeField] private ADManager ADManager;
    public Tilemap tilemap { get; private set; }
    public TetrisPiece activePiece { get; private set; }

    public TetrisTetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);

    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<TetrisPiece>();
    
        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }


    }

    private void Start()
    {
        SpawnPiece();

        if (PlayerPrefs.GetInt("tetrishighscore") < score)
            PlayerPrefs.SetInt("invadershighscore", score);
        highscoreText.text = "best:"+PlayerPrefs.GetInt("invadershighscore").ToString();
    }

    public TetrisPiece piecePrefab; // Assign this in the Unity editor with your TetrisPiece prefab

    /*  public void SpawnPiece()
      {
          if (piecePrefab == null)
          {
              Debug.LogError("Piece prefab is not assigned!");
              return;
          }

          if (activePiece == null)
          {
              // Instantiate a new TetrisPiece from the prefab
              activePiece = Instantiate(piecePrefab, this.transform);
          }

          int random = Random.Range(0, tetrominoes.Length);
          TetrisTetrominoData data = tetrominoes[random];

          activePiece.Initialize(this, spawnPosition, data);

          if (IsValidPosition(activePiece, spawnPosition))
          {
              Set(activePiece);
          }
          else
          {
              GameOver();
          }
      }*/
    public void SpawnPiece()
    {
        if (piecePrefab == null)
        {
            Debug.LogError("Piece prefab is not assigned!");
            return;
        }

        if (activePiece == null)
        {
            // Instantiate a new TetrisPiece from the prefab
            activePiece = Instantiate(piecePrefab, this.transform);
        }

        int random = Random.Range(0, tetrominoes.Length);
        TetrisTetrominoData data = tetrominoes[random];

        activePiece.Initialize(this, spawnPosition, data);

        if (IsValidPosition(activePiece, spawnPosition))
        {
            Set(activePiece);
        }
        else
        {
            GameOver();
        }
    }



    public void GameOver()
    {
        tilemap.ClearAllTiles();

        // Do anything else you want on game over here..
        score = 0;
        scoreText.text = "Score: " + score.ToString(); // Skor metnini g�ncelle
        ADManager.GecisReklamiGoster();
    }

    public void Set(TetrisPiece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(TetrisPiece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(TetrisPiece piece, Vector3Int position)
    {
        RectInt bounds = Bounds;

        // The position is only valid if every cell is valid
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            // An out of bounds tile is invalid
            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            // A tile already occupies the position, thus invalid
            if (tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = Bounds;
        int row = bounds.yMin;

        // Clear from bottom to top
        while (row < bounds.yMax)
        {
            // Only advance to the next row if the current is not cleared
            // because the tiles above will fall down when a row is cleared
            if (IsLineFull(row))
            {
                LineClear(row);
            }
            else
            {
                row++;
            }
        }
    }

    public bool IsLineFull(int row)
    {
        RectInt bounds = Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            // The line is not full if a tile is missing
            if (!tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;
    }

    public void LineClear(int row)
    {
        RectInt bounds = Bounds;

        // Clear all tiles in the row
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }

        // Shift every row above down one
        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                tilemap.SetTile(position, above);
            }

            row++;
        }

        UpdateScore(1);
    }
    public void UpdateScore(int linesCleared)
    {
        score += linesCleared * 10; // Her temizlenen sat�r i�in skoru 10 puan art�r
        scoreText.text = "Score: " + score.ToString(); // Skor metnini g�ncelle

        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 5);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 5);

        if (PlayerPrefs.GetInt("tetrishighscore") < score)
            PlayerPrefs.SetInt("invadershighscore", score);
        highscoreText.text = "best:" + PlayerPrefs.GetInt("invadershighscore").ToString();


        anim.SetTrigger("happy");
    }

    [SerializeField] private Animator anim;
}
