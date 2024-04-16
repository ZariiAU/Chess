using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rook : Piece
{
    public override List<Tile> CheckLegalMoves()
    {
        List<Tile> list = new List<Tile>();

        // East of Piece
        for (int i = (int)currentTile.gridPos.x + 1; i < gridObject.gridDimensions.GetLength(0); i++) // I = 1 to exclude self
        {
            Tile nextTile = gridObject.gridDimensions[i, (int)currentTile.gridPos.y];
            if (nextTile.pieceOnTile)
            {
                Piece nextPiece = nextTile.pieceOnTile;
                if (nextPiece && allegiance == nextPiece.allegiance)
                {
                    break;
                }
                else
                {
                    list.Add(nextTile);
                    break;
                }
            }
            list.Add(nextTile);
        }

        //// North of Piece
        for (int i = (int)currentTile.gridPos.y + 1; i < gridObject.gridDimensions.GetLength(1); i++)
        {
            Tile nextTile = gridObject.gridDimensions[(int)currentTile.gridPos.x, i];
            if (nextTile.pieceOnTile)
            {
                Piece nextPiece = nextTile.pieceOnTile;
                if (nextPiece && allegiance == nextPiece.allegiance)
                {
                    break;
                }
                else
                {
                    list.Add(nextTile);
                    break;
                }
            }
            list.Add(nextTile);
        }

        // West of Piece
        for (int i = (int)currentTile.gridPos.x - 1; i >= 0; i--)
        {
            Tile nextTile = gridObject.gridDimensions[i, (int)currentTile.gridPos.y];
            if (nextTile.pieceOnTile)
            {
                Piece nextPiece = nextTile.pieceOnTile;
                if (nextPiece && allegiance == nextPiece.allegiance)
                {
                    break;
                }
                else
                {
                    list.Add(nextTile);
                    break;
                }
            }
            list.Add(nextTile);
        }

        // South of Piece
        for (int i = (int)currentTile.gridPos.y - 1; i >= 0; i--)
        {
            Tile nextTile = gridObject.gridDimensions[(int)currentTile.gridPos.x, i];
            if (nextTile.pieceOnTile)
            {
                Piece nextPiece = nextTile.pieceOnTile;
                if (nextPiece && allegiance == nextPiece.allegiance)
                {
                    break;
                }
                else
                {
                    list.Add(nextTile);
                    break;
                }
            }
            list.Add(nextTile);
        }
        return list;
    }
}
