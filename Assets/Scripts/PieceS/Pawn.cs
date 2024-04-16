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
            MoveLateral(1, DirectionLateral.N, list, false);

            // ATTACK MOVES
            if(currentTile.gridPos.y < gridObject.gridDimensions.GetLength(1) - 1) // Don't check anything above us if we're near the north edge of the grid
            {
                // Don't check NW if we're at the min x bounds
                if (currentTile.gridPos.x > 0) 
                {
                    Tile attackTileNW = gridObject.gridDimensions[(int)currentTile.gridPos.x - 1, (int)currentTile.gridPos.y + 1];
                    if (attackTileNW.pieceOnTile)
                    {
                        MoveDiagonal(1, DirectionDiagonal.NW, list, true);
                    }
                }

                // Don't check NE if we're at the max x bounds
                if (currentTile.gridPos.x < gridObject.gridDimensions.GetLength(0) - 1) 
                {
                    Tile attackTileNE = gridObject.gridDimensions[(int)currentTile.gridPos.x + 1, (int)currentTile.gridPos.y + 1];
                    if (attackTileNE.pieceOnTile)
                    {
                        MoveDiagonal(1, DirectionDiagonal.NE, list, true);
                    }
                }
            }
        }

        // South of piece if on anything else
        else
        {
            MoveLateral(1, DirectionLateral.S, list, false);

            // ATTACK MOVES
            if (currentTile.gridPos.y > 0)
            {
                if(currentTile.gridPos.x > 0)
                {
                    Tile attackTileSW = gridObject.gridDimensions[(int)currentTile.gridPos.x - 1, (int)currentTile.gridPos.y - 1];
                    if (attackTileSW.pieceOnTile)
                    {
                        MoveDiagonal(1, DirectionDiagonal.SW, list, true);
                    }
                }
                
                if(currentTile.gridPos.x < gridObject.gridDimensions.GetLength(0) - 1)
                {
                    Tile attackTileSE = gridObject.gridDimensions[(int)currentTile.gridPos.x + 1, (int)currentTile.gridPos.y - 1];
                    if (attackTileSE.pieceOnTile)
                    {
                        MoveDiagonal(1, DirectionDiagonal.SE, list, true);
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
