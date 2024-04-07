using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Layout")]
public class PiecePlacement : SerializedScriptableObject
{
    [SerializeField] [Tooltip("Value = Coord on Grid")] 
    public Dictionary<Vector2, Piece> piecePositions = new Dictionary<Vector2, Piece>();
    public Material material;
}
