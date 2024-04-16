using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override List<Tile> CheckLegalMoves()
    {
        List<Tile> list = new List<Tile>();

        int y = (int)currentTile.gridPos.y;
        // CHECK NE
        for (int x = (int)currentTile.gridPos.x + 1; x < gridObject.gridDimensions.GetLength(0) && currentTile.gridPos.x < gridObject.gridDimensions.GetLength(0) - 1; x++) 
        {
            if (y < gridObject.gridDimensions.GetLength(1))
            {
                y++;

                Tile nextTile = gridObject.gridDimensions[x, y];
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

                list.Add(gridObject.gridDimensions[x, y]);
            }
        }

        y = (int)currentTile.gridPos.y;
        // CHECK NW
        for (int x = (int)currentTile.gridPos.x - 1; x >= 0 && currentTile.gridPos.x > 0; x--) 
        {
            if(y < gridObject.gridDimensions.GetLength(1))
            {
                y++;

                Tile nextTile = gridObject.gridDimensions[x, y];
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

                list.Add(gridObject.gridDimensions[x, y]);
            }
        }

        y = (int)currentTile.gridPos.y;
        // CHECK SE
        for (int x = (int)currentTile.gridPos.x + 1; x < gridObject.gridDimensions.GetLength(0); x++) 
        {
            if(y > 0)
            {
                y--;

                Tile nextTile = gridObject.gridDimensions[x, y];
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

                list.Add(gridObject.gridDimensions[x, y]);
            }
        }

        y = (int)currentTile.gridPos.y;
        // CHECK SW
        for (int x = (int)currentTile.gridPos.x - 1; x > 0; x--) 
        {
            if (y > 0)
            {
                y--;

                Tile nextTile = gridObject.gridDimensions[x, y];
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

                list.Add(gridObject.gridDimensions[x, y]);
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
