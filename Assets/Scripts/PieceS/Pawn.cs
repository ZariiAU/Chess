using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    int maxMovement = 1;
    public override void CheckLegalMoves()
    {
        for (int x = 0; x < gridObject.xSize; x++)
        {
            for (int y = 0; y < gridObject.ySize; y++)
            {
                if (gridObject.gridDimensions[x, y].pieceOnTile.gameObject == gameObject)
                {
                    
                }
            }
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
