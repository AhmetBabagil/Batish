using System.Collections.Generic;
using UnityEngine;

public class CheckersBot
{
    private List<CheckersPiece> pieces;

    public CheckersBot(List<CheckersPiece> pieces)
    {
        this.pieces = pieces;
    }

    public (CheckersPiece, Vector2Int) CalculateMove()
    {
        // Burada bot'un bir hamle hesaplamasý yapýlacak
        // Bu örnek için rastgele bir hamle döndürelim
        foreach (var piece in pieces)
        {
            if (piece.Color == CheckersPiece.PieceColor.Black)
            {
                // Rastgele bir hamle döndür
                return (piece, new Vector2Int(piece.Position.x + 1, piece.Position.y + 1));
            }
        }

        return (null, new Vector2Int());
    }
}
