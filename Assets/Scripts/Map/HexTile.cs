using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class HexTile : MonoBehaviour
{

    public HextileGenerationSettings settings;

    public HextileGenerationSettings.TileType tileType = (HextileGenerationSettings.TileType)0;

    private bool Visible = false;
	private bool Covered = false;

    public GameObject TileObject;
    public GameObject TileAnimation;
    public GameObject fow;

    private bool isDirty = false;
    float m_ScaleX = 2.0f;
    float m_ScaleY = 2.8f;
    float m_ScaleZ = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    private void Update()
    {
        if(isDirty)
        {

            if(Application.isPlaying)
            {
                GameObject.Destroy(TileObject);
            }
            else
            {
                GameObject.DestroyImmediate(TileObject);
            }
            
            AddTile();
            isDirty = false;

        }

    }

    //Asigna tipo de tile aleatoriamente. rango de 0 a 6 porque el limite derecho no es inclusivo, es decir, no se cuenta
    public void RollTileType()
    {
        tileType = (HextileGenerationSettings.TileType)Random.Range(0,6);
    }

    public void AddTile()
    {
        TileObject = GameObject.Instantiate(settings.GetTile(tileType));
        if (TileObject.GetComponent<BoxCollider>() == null)
        {
            
            BoxCollider reach = TileObject.AddComponent<BoxCollider>();
            reach.size = new Vector3(m_ScaleX,m_ScaleY,m_ScaleZ);

        }
        TileObject.transform.SetParent(gameObject.transform,true);
    }

    private void OnValidate()
    {
        if(TileObject==null){return;}
        isDirty = true;
    }

    
    // public void OnHighlightTile(){
    //     TileMap.instance.OnHighlightTile(this);
    // }

    // public void OnSelectTile(){
    //     TileMap.instance.OnSelectTile(this);
    // }
}
