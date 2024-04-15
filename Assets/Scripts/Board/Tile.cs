using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool occupied;
    public Piece pieceOnTile;
    public GameObject highlightEffect;
    public GameObject legalMoveEffect;
    public Vector2 gridPos;
}
