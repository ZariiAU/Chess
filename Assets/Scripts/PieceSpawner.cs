using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] PiecePlacement blackPlacement;
    [SerializeField] PiecePlacement whitePlacement;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<Grid>();

        GameObject whitePieceContainer = new GameObject();
        whitePieceContainer.name = "!White Pieces!";
        whitePieceContainer.transform.parent = transform;

        foreach (var key in whitePlacement.piecePositions.Keys)
        {
            whitePlacement.piecePositions.TryGetValue(key, out Piece piece);
            if (piece)
            {
                GameObject go = Instantiate(piece.gameObject);
                
                go.transform.position = new Vector3(key.x, 0, key.y);
                go.gameObject.name = $"whitePiece: {key.x}:{key.y}";
                go.transform.parent = whitePieceContainer.transform;
            }
        }

        GameObject blackPieceContainer = new GameObject();
        blackPieceContainer.name = "!Black Pieces!";
        blackPieceContainer.transform.parent = transform;

        foreach (var key in blackPlacement.piecePositions.Keys)
        {
            blackPlacement.piecePositions.TryGetValue(key, out Piece piece);
            if (piece)
            {
                GameObject go = Instantiate(piece.gameObject);
                
                go.transform.position = new Vector3(key.x, 0, key.y);
                go.gameObject.name = $"blackPiece: {key.x}:{key.y}";
                go.transform.parent = blackPieceContainer.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
