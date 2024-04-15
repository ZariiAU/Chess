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
                if (selectedTile && clickedTile == selectedTile)
                {
                    ToggleLegalMoveEffect(clickedTile.pieceOnTile, false);
                    selectedTile = null;
                }
                else if (!selectedTile && clickedTile.pieceOnTile)
                {
                    ToggleLegalMoveEffect(clickedTile.pieceOnTile, true);
                    selectedTile = clickedTile;
                }
                else if (selectedTile && !clickedTile.pieceOnTile && selectedTile.pieceOnTile.CheckLegalMoves().Contains(clickedTile)) // Move into empty space
                {
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                    clickedTile.pieceOnTile = selectedTile.pieceOnTile;
                    selectedTile.pieceOnTile.transform.position = clickedTile.transform.position;
                    selectedTile.pieceOnTile.currentTile = clickedTile;
                    selectedTile.pieceOnTile = null;
                    selectedTile = null;
                }
                else if (selectedTile && !clickedTile.pieceOnTile && !selectedTile.pieceOnTile.CheckLegalMoves().Contains(clickedTile))
                {
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                    selectedTile = null;
                }
                else if (selectedTile && selectedTile != clickedTile)
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
