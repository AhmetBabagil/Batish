using System.Collections;
using UnityEngine;
using TMPro;


public class MineSweeperGame : MonoBehaviour
{
    public int width = 16;
    public int height = 16;
    public int mineCount = 32;

    private MineSweeperBoard board;
    private MineSweeperCellGrid grid;
    private bool gameover;
    private bool generated;

    private void OnValidate()
    {
        mineCount = Mathf.Clamp(mineCount, 0, width * height);
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        board = GetComponentInChildren<MineSweeperBoard>();
    }

    private void Start()
    {
        NewGame();
      
    }


    private void NewGame()
    {
        StopAllCoroutines();

        Camera.main.transform.position = new Vector3(width / 2f, height / 2f, -10f);

        gameover = false;
        generated = false;

        grid = new MineSweeperCellGrid(width, height);
        board.Draw(grid);


        scoreTimer = 0f; // Yeni oyun baþladýðýnda timer'ý sýfýrla.
        UpdateScoreDisplay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            NewGame();
            return;
        }

        if (!gameover)
        {
            /*    if (Input.GetMouseButtonDown(0))
                {
                    Reveal();
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Flag();
                }
            */
            if (Input.GetMouseButtonDown(0)&& !isFlagging)
            {
                Reveal();
            }
            else if (Input.GetMouseButtonDown(0)&& isFlagging)
            {
                Flag();
            }
            else if (Input.GetMouseButton(2))
            {
                Chord();
            }
            else if (Input.GetMouseButtonUp(2))
            {
                Unchord();
            }
        }


        if (!gameover)
        {
            // Oyun sürerken ve mayýnlar oluþturulduktan sonra timer'ý güncelle.
            scoreTimer += Time.deltaTime;
            UpdateScoreDisplay();
        }
    
    }

    private void Reveal()
    {
        if (TryGetCellAtMousePosition(out MineSweeperCell cell))
        {
            if (!generated)
            {
                grid.GenerateMines(cell, mineCount);
                grid.GenerateNumbers();
                generated = true;
            }

            Reveal(cell);
        }
    }

    private void Reveal(MineSweeperCell cell)
    {
        if (cell.revealed) return;
        if (cell.flagged) return;

        switch (cell.type)
        {
            case MineSweeperCell.Type.Mine://MAYINA BASTI
                Explode(cell);
                ADManager.GecisReklamiGoster();
                break;

            case MineSweeperCell.Type.Empty://boþ cell buldu
                StartCoroutine(Flood(cell));
                CheckWinCondition();
                break;

            default:
                cell.revealed = true;
                CheckWinCondition(); 
                break;
        }

        board.Draw(grid);
    }

    private IEnumerator Flood(MineSweeperCell cell)
    {
        if (gameover) yield break;
        if (cell.revealed) yield break;
        if (cell.type == MineSweeperCell.Type.Mine) yield break;

        cell.revealed = true;
        board.Draw(grid);

        yield return null;

        if (cell.type == MineSweeperCell.Type.Empty)
        {
            if (grid.TryGetCell(cell.position.x - 1, cell.position.y, out MineSweeperCell left))
            {
                StartCoroutine(Flood(left));
            }
            if (grid.TryGetCell(cell.position.x + 1, cell.position.y, out MineSweeperCell right))
            {
                StartCoroutine(Flood(right));
            }
            if (grid.TryGetCell(cell.position.x, cell.position.y - 1, out MineSweeperCell down))
            {
                StartCoroutine(Flood(down));
            }
            if (grid.TryGetCell(cell.position.x, cell.position.y + 1, out MineSweeperCell up))
            {
                StartCoroutine(Flood(up));
            }
        }
    }

    private void Flag()
    {
        if (!TryGetCellAtMousePosition(out MineSweeperCell cell)) return;
        if (cell.revealed) return;

        cell.flagged = !cell.flagged;
        board.Draw(grid);
    }

    private void Chord()
    {
        // unchord previous cells
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y].chorded = false;
            }
        }

        // chord new cells
        if (TryGetCellAtMousePosition(out MineSweeperCell chord))
        {
            for (int adjacentX = -1; adjacentX <= 1; adjacentX++)
            {
                for (int adjacentY = -1; adjacentY <= 1; adjacentY++)
                {
                    int x = chord.position.x + adjacentX;
                    int y = chord.position.y + adjacentY;

                    if (grid.TryGetCell(x, y, out MineSweeperCell cell))
                    {
                        cell.chorded = !cell.revealed && !cell.flagged;
                    }
                }
            }
        }

        board.Draw(grid);
    }

    private void Unchord()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                MineSweeperCell cell = grid[x, y];

                if (cell.chorded)
                {
                    Unchord(cell);
                }
            }
        }

        board.Draw(grid);
    }

    private void Unchord(MineSweeperCell chord)
    {
        chord.chorded = false;

        for (int adjacentX = -1; adjacentX <= 1; adjacentX++)
        {
            for (int adjacentY = -1; adjacentY <= 1; adjacentY++)
            {
                if (adjacentX == 0 && adjacentY == 0)
                {
                    continue;
                }

                int x = chord.position.x + adjacentX;
                int y = chord.position.y + adjacentY;

                if (grid.TryGetCell(x, y, out MineSweeperCell cell))
                {
                    if (cell.revealed && cell.type == MineSweeperCell.Type.Number)
                    {
                        if (grid.CountAdjacentFlags(cell) >= cell.number)
                        {
                            Reveal(chord);
                            return;
                        }
                    }
                }
            }
        }
    }

    private void Explode(MineSweeperCell cell)
    {
        Debug.Log("Game Over!");
        gameover = true;

        // Set the mine as exploded
        cell.exploded = true;
        cell.revealed = true;

        // Reveal all other mines
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cell = grid[x, y];

                if (cell.type == MineSweeperCell.Type.Mine)
                {
                    cell.revealed = true;
                }
            }
        }

        // Bekleme süresi sonunda yeni oyunu baþlat
        // Burada 2 saniye bekleme süresi örneði verilmiþtir, ihtiyaca göre ayarlanabilir
       
        Invoke(nameof(NewGame), 2f);
      
    }

    private void CheckWinCondition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                MineSweeperCell cell = grid[x, y];

                // All non-mine cells must be revealed to have won
                if (cell.type != MineSweeperCell.Type.Mine && !cell.revealed)
                {
                    return; // no win
                }
            }
        }

        Debug.Log("Winner!");
        gameover = true;

        // Flag all the mines
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                MineSweeperCell cell = grid[x, y];

                if (cell.type == MineSweeperCell.Type.Mine)
                {
                    cell.flagged = true;
                }
            }
        }
     
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 100);
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("xp") + 50);
        Invoke(nameof(NewGame), 2f);
    }

    private bool TryGetCellAtMousePosition(out MineSweeperCell cell)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = board.tilemap.WorldToCell(worldPosition);
        return grid.TryGetCell(cellPosition.x, cellPosition.y, out cell);
    }

    private bool isFlagging = false;

    public void isFlaggingSetTRUE()
    {
        isFlagging = true;
    }
    public void isFlaggingSetFALSE()
    {
        isFlagging = false;
    }
    [SerializeField] private ADManager ADManager;
    private float scoreTimer = 0f; // Skor timer'ýný tutacak deðiþken.
    public TextMeshProUGUI scoreText; // Skoru gösterecek UI elementi.

    private void UpdateScoreDisplay()
    {
        // Skorun UI'da gösterilmesi için formatlama.
        // Örneðin: "Score: 123"
        if (scoreText != null)
        {
            scoreText.text = "Time: " + Mathf.FloorToInt(scoreTimer).ToString();
        }
    }



}
