using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Data For the player
public class PlayerData 
{
    public PlayerData() { }
    public PlayerData(int MaxHP) 
    {
        MaxHealth = MaxHP;
        CurrHealth = MaxHealth;
        currTile = null;
        AllowedMoves = 10;
    }

   

    private int CurrHealth;
    private int MaxHealth;
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
