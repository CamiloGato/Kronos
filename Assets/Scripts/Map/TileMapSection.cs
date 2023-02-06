using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileMapSection : MonoBehaviour
{
    public Vector2Int gridSize;//Rows x Colummns
    public bool isFlatTopped; //Orientacion de la casilla
    public float height; //Altura de la casilla
    public float lenght; //Longitud de la casilla
    
    public HextileGenerationSettings settings; //Selector de modelo para las casillas
    public GameObject highlight;
    public GameObject selector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Cleans the structure
    public void Clear(){
        List<GameObject> children = new List<GameObject>();

        for (int i=0; i<transform.childCount;i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            children.Add(child);
        }

        foreach(GameObject child in children){
            DestroyImmediate(child,true);
        }


    }

    // Makes specific tile become highlighted.
    // public void OnHighlightTile(HexTile tile)
    // {
    //     highlight.transform.position = tile.transform.position;
    // }

    // Makes tile become selected.
    // public void OnSelectTile(HexTile tile)
    // {
    //     selector.transform.position = tile.transform.position;
    // }

    //[EditorButton("Layout")]
    public void LayoutGrid()
    {
        Clear();
        for (int y=0; y < gridSize.y; y++)
        {
            for(int x=0; x < gridSize.x; x++)
            {
                GameObject tile= new GameObject($"Hex C{x},R{y}");

                HexTile hextile = tile.AddComponent<HexTile>();
                hextile.settings = settings;
                hextile.RollTileType();
                hextile.AddTile();

            }
        }
    }

}
