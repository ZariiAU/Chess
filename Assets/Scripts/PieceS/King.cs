using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public override List<Tile> CheckLegalMoves()
    {
        List<Tile> list = new List<Tile>();
        MoveLateral(1, DirectionLateral.N, list);
        MoveLateral(1, DirectionLateral.E, list);
        MoveLateral(1, DirectionLateral.S, list);
        MoveLateral(1, DirectionLateral.W, list);

        MoveDiagonal(1, DirectionDiagonal.NE, list);
        MoveDiagonal(1, DirectionDiagonal.NW, list);
        MoveDiagonal(1, DirectionDiagonal.SE, list);
        MoveDiagonal(1, DirectionDiagonal.SW, list);
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
