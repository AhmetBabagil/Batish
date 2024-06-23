using UnityEngine;

public class CheckersPiece
{
    public enum PieceType { Normal, King }
    public enum PieceColor { White, Black }

    public PieceType Type { get; set; }
    public PieceColor Color { get; private set; }
    public Vector2Int Position { get; set; }

    public CheckersPiece(PieceColor color, Vector2Int position)
    {
        Color = color;
        Position = position;
        Type = PieceType.Normal;
    }
}
