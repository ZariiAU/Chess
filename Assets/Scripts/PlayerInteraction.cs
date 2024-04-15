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
                hit.collider.gameObject.TryGetComponent<Tile>(out Tile _selectedTile);
                if (selectedTile && _selectedTile == selectedTile)
                {
                    ToggleLegalMoveEffect(_selectedTile.pieceOnTile, false);
                    selectedTile = null;
                }
                else if (!selectedTile && _selectedTile.pieceOnTile)
                {
                    ToggleLegalMoveEffect(_selectedTile.pieceOnTile, true);
                    selectedTile = _selectedTile;
                }
                else if (selectedTile && selectedTile != _selectedTile)
                {
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, false);
                    selectedTile = _selectedTile;
                    ToggleLegalMoveEffect(selectedTile.pieceOnTile, true);
                }
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
