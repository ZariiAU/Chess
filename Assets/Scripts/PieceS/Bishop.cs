using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override List<Tile> CheckLegalMoves()
    {
        List<Tile> list = new List<Tile>();


        // CHECK NE
        MoveDiagonal(0, DirectionDiagonal.NE, list);
        // CHECK NW
        MoveDiagonal(0, DirectionDiagonal.NW, list);
        // CHECK SE
        MoveDiagonal(0, DirectionDiagonal.SE, list);
        // CHECK SW
        MoveDiagonal(0, DirectionDiagonal.SW, list);

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
