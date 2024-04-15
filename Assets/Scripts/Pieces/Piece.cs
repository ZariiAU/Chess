using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public AllegianceData allegiance;
    public List<Tile> legalMovePoints;
    public Grid gridObject;
    public Tile currentTile;

    public abstract List<Tile> CheckLegalMoves();
}
