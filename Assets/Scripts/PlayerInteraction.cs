using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    Camera _camera;
    [SerializeField] Tile hoveredTile;
    [SerializeField] Tile selectedTile;

    void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Tile highlightedTile;
            hit.collider.gameObject.TryGetComponent<Tile>(out highlightedTile);
            if (hoveredTile)
            {
                if (highlightedTile && highlightedTile != hoveredTile)
                {
                    hoveredTile.highlightEffect.SetActive(false);
                    hoveredTile = highlightedTile;
                }
            }
            
            if (highlightedTile) 
            {
                hoveredTile = highlightedTile;
                highlightedTile.highlightEffect.SetActive(true);
            }
        }
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                hit.collider.gameObject.TryGetComponent<Tile>(out Tile clickedTile);
                if (selectedTile && clickedTile == selectedTile) // Select the selected tile again should clear the selection
                {
                    ToggleLegalMoveEffect(clickedTile.pieceOnTile, false);
                    selectedTile = null;
                }

                else if (!selectedTile && clickedTile.pieceOnTile) // Selected tile with a piece on it
                {
                    ToggleLegalMoveEffect(clickedTile.pieceOnTile, true);
                    selectedTile = clickedTile;
                }

                else if (selectedTile && !clickedTile.pieceOnTile && selectedTile.pieceOnTile.CheckLegalMoves().Contains(clickedTile)) // Move into empty space
                {
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                    clickedTile.pieceOnTile = selectedTile.pieceOnTile;
                    selectedTile.pieceOnTile.OnMoved.Invoke();
                    selectedTile.pieceOnTile.transform.position = clickedTile.transform.position;
                    selectedTile.pieceOnTile.currentTile = clickedTile;
                    selectedTile.pieceOnTile = null;
                    selectedTile = null;
                }

                else if (selectedTile && clickedTile.pieceOnTile && 
                    clickedTile.pieceOnTile.allegiance != selectedTile.pieceOnTile.allegiance && 
                    selectedTile.pieceOnTile.CheckLegalMoves().Contains(clickedTile)) // Take an enemy piece
                {
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                    clickedTile.pieceOnTile.gameObject.SetActive(false); // Hide Game Object or do something else
                    clickedTile.pieceOnTile = null;

                    selectedTile.pieceOnTile.OnPieceTaken.Invoke();

                    clickedTile.pieceOnTile = selectedTile.pieceOnTile;
                    selectedTile.pieceOnTile.transform.position = clickedTile.transform.position;
                    selectedTile.pieceOnTile.currentTile = clickedTile;
                    selectedTile.pieceOnTile = null;
                    selectedTile = null;
                }

                else if (selectedTile && !clickedTile.pieceOnTile && !selectedTile.pieceOnTile.CheckLegalMoves().Contains(clickedTile)) // Selected a position to move that was invalid
                {
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                    selectedTile = null;
                }

                else if (selectedTile && selectedTile != clickedTile) // Selected another piece
                {
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                    selectedTile = clickedTile;
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, true);
                }
            }
            else if(selectedTile)
            {
                ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                selectedTile = null;
            }
        }
    }
    void ToggleLegalMoveEffect(Piece inputPiece, bool effectEnabled)
    {
        if(inputPiece.CheckLegalMoves().Count > 0)
        {
            foreach (Tile t in inputPiece.CheckLegalMoves())
            {
                t.legalMoveEffect.SetActive(effectEnabled);
            }
        }
    }
}
