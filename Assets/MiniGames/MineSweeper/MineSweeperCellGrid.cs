using UnityEngine;

public class MineSweeperCellGrid
{
    private readonly MineSweeperCell[,] cells;

    public int Width => cells.GetLength(0);
    public int Height => cells.GetLength(1);

    public MineSweeperCell this[int x, int y] => cells[x, y];

    public MineSweeperCellGrid(int width, int height)
    {
        cells = new MineSweeperCell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cells[x, y] = new MineSweeperCell
                {
                    position = new Vector3Int(x, y, 0),
                    type = MineSweeperCell.Type.Empty
                };
            }
        }
    }

    public void GenerateMines(MineSweeperCell startingCell, int amount)
    {
        int width = Width;
        int height = Height;

        for (int i = 0; i < amount; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            MineSweeperCell cell = cells[x, y];

            while (cell.type == MineSweeperCell.Type.Mine || IsAdjacent(startingCell, cell))
            {
                x++;

                if (x >= width)
                {
                    x = 0;
                    y++;

                    if (y >= height)
                    {
                        y = 0;
                    }
                }

                cell = cells[x, y];
            }

            cell.type = MineSweeperCell.Type.Mine;
        }
    }

    public void GenerateNumbers()
    {
        int width = Width;
        int height = Height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                MineSweeperCell cell = cells[x, y];

                if (cell.type == MineSweeperCell.Type.Mine)
                {
                    continue;
                }

                cell.number = CountAdjacentMines(cell);
                cell.type = cell.number > 0 ? MineSweeperCell.Type.Number : MineSweeperCell.Type.Empty;
            }
        }
    }

    public int CountAdjacentMines(MineSweeperCell cell)
    {
        int count = 0;

        for (int adjacentX = -1; adjacentX <= 1; adjacentX++)
        {
            for (int adjacentY = -1; adjacentY <= 1; adjacentY++)
            {
                if (adjacentX == 0 && adjacentY == 0)
                {
                    continue;
                }

                int x = cell.position.x + adjacentX;
                int y = cell.position.y + adjacentY;

                if (TryGetCell(x, y, out MineSweeperCell adjacent) && adjacent.type == MineSweeperCell.Type.Mine)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public int CountAdjacentFlags(MineSweeperCell cell)
    {
        int count = 0;

        for (int adjacentX = -1; adjacentX <= 1; adjacentX++)
        {
            for (int adjacentY = -1; adjacentY <= 1; adjacentY++)
            {
                if (adjacentX == 0 && adjacentY == 0)
                {
                    continue;
                }

                int x = cell.position.x + adjacentX;
                int y = cell.position.y + adjacentY;

                if (TryGetCell(x, y, out MineSweeperCell adjacent) && !adjacent.revealed && adjacent.flagged)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public MineSweeperCell GetCell(int x, int y)
    {
        if (InBounds(x, y))
        {
            return cells[x, y];
        }
        else
        {
            return null;
        }
    }

    public bool TryGetCell(int x, int y, out MineSweeperCell cell)
    {
        cell = GetCell(x, y);
        return cell != null;
    }

    public bool InBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public bool IsAdjacent(MineSweeperCell a, MineSweeperCell b)
    {
        return Mathf.Abs(a.position.x - b.position.x) <= 1 &&
               Mathf.Abs(a.position.y - b.position.y) <= 1;
    }

}