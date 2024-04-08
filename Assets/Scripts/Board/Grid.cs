using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class Grid : MonoBehaviour
{
    [SerializeField] public GameObject boardGameObject;
    [SerializeField] public int xSize = 8;
    [SerializeField] public int ySize = 8;
    [TableMatrix] public Tile[,] gridDimensions;
    [SerializeField] float tileSizeX = 1;
    [SerializeField] float tileSizeY = 1;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] Material oddColor;
    [SerializeField] Material evenColor;

    void Awake()
    {
       gridDimensions = new Tile[xSize, ySize];

       for(int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Vector3 pos = new Vector3(x,0,y);
                GameObject go = Instantiate(tilePrefab, transform);

                gridDimensions[x,y] = go.GetComponent<Tile>();
                go.transform.position = pos;
                go.transform.localScale = new Vector3(tileSizeX, tileSizeY, 1);

                Material mat = go.GetComponent<MeshRenderer>().material;

                string whiteTileName = $"WhiteTile: {x}:{y}";
                string blackTileName = $"BlackTile: {x}:{y}";

                if (x % 2 != 0 && y % 2 != 0 ||
                    x % 2 == 0 && y % 2 == 0)
                {
                    mat.color = Color.black;
                    go.name = blackTileName;
                    go.GetComponentInChildren<TMP_Text>().text = blackTileName;
                }
                else
                {
                    mat.color = Color.white;
                    go.name = whiteTileName;
                    go.GetComponentInChildren<TMP_Text>().text = whiteTileName;
                }
                gridDimensions.SetValue(go.GetComponent<Tile>(), x, y);
            }
        }
    }

    void Update()
    {
        
    }
}
