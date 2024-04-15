using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Tile> CheckLegalMoves()
    {
        List<Tile> list = new List<Tile>();

        //// North of Piece
        if(allegiance == gridObject.GetComponent<PieceSpawner>().whiteData)
        {
            for (int i = (int)currentTile.gridPos.y + 1; i < (int)currentTile.gridPos.y + 2; i++)
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
                        // ATTACK!!!
                    }
                }
                list.Add(nextTile);
            }
        }
        else
        {
            for (int i = (int)currentTile.gridPos.y - 1; i >= 0 && i > (int)currentTile.gridPos.y - 2; i--)
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
                        // ATTACK!!!
                    }
                }
                list.Add(nextTile);
            }
        }

        
        return list;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
