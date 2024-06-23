using UnityEngine;
using UnityEngine.Tilemaps;

public enum TetrisTetromino
{
    I, J, L, O, S, T, Z
}

[System.Serializable]
public struct TetrisTetrominoData
{
    public TileBase tile;
    public TetrisTetromino tetromino;

    public Vector2Int[] cells { get; private set; }
    public Vector2Int[,] wallKicks { get; private set; }

    public void Initialize()
    {
        cells = TetrisData.Cells[tetromino];
        wallKicks = TetrisData.WallKicks[tetromino];
    }

}