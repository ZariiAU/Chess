using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public abstract class Piece : MonoBehaviour
{
    public AllegianceData allegiance;
    public List<Tile> legalMovePoints;
    public Grid gridObject;
    public Tile currentTile;

    public UnityEvent OnMoved;
    public UnityEvent OnPieceTaken;
    public UnityEvent OnSelected;

    public abstract List<Tile> CheckLegalMoves();
}
