using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    Camera _camera;
    Tile hoveredTile;

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
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }
    }
}
