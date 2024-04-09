using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] PiecePlacement blackPlacement;
    [SerializeField] PiecePlacement whitePlacement;
    [SerializeField] AllegianceData whiteData;
    [SerializeField] AllegianceData blackData;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Grid>();

        SpawnPieces(whitePlacement.piecePositions, whiteData, "!White Pieces!", "whitePiece");
        SpawnPieces(blackPlacement.piecePositions, blackData, "!Black Pieces!", "blackPiece");
    }

    List<Piece> SpawnPieces(Dictionary<Vector2, Piece> initialPositions, AllegianceData team ,string containerName, string gameObjectName)
    {
        List<Piece> piecesSpawned = new List<Piece>();

        foreach (var key in initialPositions.Keys)
        {
            initialPositions.TryGetValue(key, out Piece piece);
            if (piece)
            {
                Tile targetTile = grid.gridDimensions[(int)key.x, (int)key.y];
                GameObject go = Instantiate(piece.gameObject);

                Piece pieceClone = go.GetComponent<Piece>();
                pieceClone.currentTile = targetTile;
                pieceClone.allegiance = team;

                go.transform.position = targetTile.transform.position;
                go.gameObject.name = $"{gameObjectName}: {key.x}:{key.y}";
                go.transform.parent = targetTile.transform;

                targetTile.pieceOnTile = piece; // Setup the tile underneath this piece

                foreach(MeshRenderer mr in go.GetComponentsInChildren<MeshRenderer>())
                {
                    mr.material = team.teamMaterial;
                }
                
                piecesSpawned.Add(go.GetComponent<Piece>());
            }
        }
        return piecesSpawned;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
