using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override List<Tile> CheckLegalMoves()
    {
        List<Tile> list = new List<Tile>();

        MoveLateral(0, DirectionLateral.N, list);
        MoveLateral(0, DirectionLateral.E, list);
        MoveLateral(0, DirectionLateral.S, list);
        MoveLateral(0, DirectionLateral.W, list);

        MoveDiagonal(0,DirectionDiagonal.NE, list);
        MoveDiagonal(0,DirectionDiagonal.NW, list);
        MoveDiagonal(0,DirectionDiagonal.SE, list);
        MoveDiagonal(0,DirectionDiagonal.SW, list);

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
