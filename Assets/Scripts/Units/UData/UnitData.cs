using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Data For the player
[CreateAssetMenu(menuName = "CreateUnit",fileName = "newUnit")]
public class UnitData :ScriptableObject
{
    //Modifiable Stats
    public string UnitName;
    [TextArea(10,20)]
    public string UnitDescription;

    public Sprite UnitImage;

   //used to set the health at the start of the game
    public int Health;
    public int Damage;
    public int Defense;


    private int AllowedMoves;
    private Tile currTile;


    public void AddAllowedMoves(int allowedMoves)
    { 
        AllowedMoves += allowedMoves;
    }

    public int GetAllowedMoves()
    { 
        return AllowedMoves;
    }

    public void SetCurrentTile(GameObject tile)
    {
        currTile = tile.GetComponent<Tile>();
    }
    public Tile GetCurrentTile()
    {
        return currTile;
    }

   
}
