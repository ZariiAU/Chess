using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Tile> CheckLegalMoves()
    {
        List<Tile> list = new List<Tile>();

        //// North of Piece if on white team
        if(allegiance == gridObject.GetComponent<PieceSpawner>().whiteData)
        {
            for (int i = (int)currentTile.gridPos.y + 1; i < (int)currentTile.gridPos.y + 2 && i < gridObject.gridDimensions.GetLength(1); i++)
            {
                Tile nextTile = gridObject.gridDimensions[(int)currentTile.gridPos.x, i];
                if (nextTile.pieceOnTile)
                {
                    Piece nextPiece = nextTile.pieceOnTile;
                    if (nextPiece)
                    {
                        break;
                    }
                }
                list.Add(nextTile);
            }

            // ATTACK MOVES
            if(currentTile.gridPos.y < gridObject.gridDimensions.GetLength(1) - 1) // Don't check anything above us if we're near the north edge of the grid
            {
                // Don't check NW if we're at the min x bounds
                if (currentTile.gridPos.x > 0) 
                {
                    Tile attackTileNW = gridObject.gridDimensions[(int)currentTile.gridPos.x - 1, (int)currentTile.gridPos.y + 1];
                    if (attackTileNW.pieceOnTile)
                    {
                        Piece nextPiece = attackTileNW.pieceOnTile;
                        if (nextPiece && allegiance != nextPiece.allegiance)
                        {
                            list.Add(attackTileNW);
                        }
                    }
                }

                // Don't check NE if we're at the max x bounds
                if (currentTile.gridPos.x < gridObject.gridDimensions.GetLength(0) - 1) 
                {
                    Tile attackTileNE = gridObject.gridDimensions[(int)currentTile.gridPos.x + 1, (int)currentTile.gridPos.y + 1];
                    if (attackTileNE.pieceOnTile)
                    {
                        Piece nextPiece = attackTileNE.pieceOnTile;
                        if (nextPiece && allegiance != nextPiece.allegiance)
                        {
                            list.Add(attackTileNE);
                        }
                    }
                }
            }
        }

        // South of piece if on anything else
        else
        {
            for (int i = (int)currentTile.gridPos.y - 1; i >= 0 && i > (int)currentTile.gridPos.y - 2; i--)
            {
                Tile nextTile = gridObject.gridDimensions[(int)currentTile.gridPos.x, i];
                if (nextTile.pieceOnTile)
                {
                    Piece nextPiece = nextTile.pieceOnTile;
                    if (nextPiece)
                    {
                        break;
                    }
                }
                list.Add(nextTile);
            }
            
            // ATTACK MOVES
            if (currentTile.gridPos.y > 0)
            {
                if(currentTile.gridPos.x > 0)
                {
                    Tile attackTileSW = gridObject.gridDimensions[(int)currentTile.gridPos.x - 1, (int)currentTile.gridPos.y - 1];
                    if (attackTileSW.pieceOnTile)
                    {
                        Piece nextPiece = attackTileSW.pieceOnTile;
                        if (nextPiece && allegiance != nextPiece.allegiance)
                        {
                            list.Add(attackTileSW);
                        }
                    }
                }
                
                if(currentTile.gridPos.x < gridObject.gridDimensions.GetLength(0) - 1)
                {
                    Tile attackTileSE = gridObject.gridDimensions[(int)currentTile.gridPos.x + 1, (int)currentTile.gridPos.y - 1];
                    if (attackTileSE.pieceOnTile)
                    {
                        Piece nextPiece = attackTileSE.pieceOnTile;
                        if (nextPiece && allegiance != nextPiece.allegiance)
                        {
                            list.Add(attackTileSE);
                        }
                    }
                }
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
