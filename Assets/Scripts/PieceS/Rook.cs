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
        MoveLateral(0, DirectionLateral.E, list);

        //// North of Piece
        MoveLateral(0, DirectionLateral.N, list);

        // West of Piece
        MoveLateral(0, DirectionLateral.W, list);

        // South of Piece
        MoveLateral(0, DirectionLateral.S, list);
        return list;

    }
}
