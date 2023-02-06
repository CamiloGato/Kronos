using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TileGen/GenerationSettings")]
public class HextileGenerationSettings : ScriptableObject
{
    public enum TileType
    {
        Start,
        Earth,
        Nutrient,
        Damage,
        Trash,
        Goal
    
    }

    public GameObject Start;
    public GameObject Earth;
    public GameObject Nutrient;
    public GameObject Damage;
    public GameObject Trash;
    public GameObject Goal;

    public GameObject GetTile(TileType tileType){
        switch(tileType){
            case TileType.Start:
                return Start;
            case TileType.Earth:
                return Earth;
            case TileType.Nutrient:
                return Nutrient;
            case TileType.Damage:
                return Damage;
            case TileType.Trash:
                return Trash;
            case TileType.Goal:
                return Goal;
        }
        return null;       
    }

}
