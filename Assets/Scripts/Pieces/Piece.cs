using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public Team team;
    public List<Tile> legalMovePoints;

    public abstract void CheckLegalMoves();
}
