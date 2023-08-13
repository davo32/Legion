using UnityEngine;
using NovaUtils;

public enum TileState
{
    NONE,
    OCCUPIED,
    UNOCCUPIED,
    CURRENTTILE
}
public enum TileType
{ 
    NORMAL,
    PICKUP
}
public class TileData 
{
    public TileData() { }
    
    private Color PanelColor = Color.blue;
    private TileState tileState = TileState.UNOCCUPIED;
    private TileType tileType = TileType.NORMAL;
    private int MovesToAdd = 5;


    public void SetMovesToAdd(int moves)
    { 
        MovesToAdd = moves;
    }
    public int GetMovesToAdd()
    { 
        return MovesToAdd;
    }
    public void SetTileType(TileType type)
    { 
        tileType = type;
    }
    public TileType GetTileType()
    {
        return tileType;
    }

    public void TypeLogic(Unit player, Tile tile)
    {
        switch (tileType)
        {
            case TileType.NORMAL:
                {
                    //Do Nothing
                    break;
                }
            case TileType.PICKUP: 
                {
                    break;
                }
        }
    }
    public Color StateLogic(Unit player, GameObject tile)
    {
        if (player == null || !player.canMove)
        {
            return PanelColor = Color.red;
        }
        else
        {
            switch (tileState)
            {
                case TileState.OCCUPIED:
                    {
                        return PanelColor = Color.red;
                    }
                case TileState.UNOCCUPIED:
                    {
                        if (Vector3.Distance(player.unitData.GetCurrentTile().transform.position, tile.transform.position) <= player.walkDistance)
                        {
                            PanelColor = Color.green;
                        }
                        else
                        {
                            PanelColor = Color.red;
                        }
                        return PanelColor;
                    }
                case TileState.CURRENTTILE:
                    {
                        PanelColor = Color.magenta;
                        return PanelColor;
                    }

            }
        }

        return PanelColor;
    }
    public void SetTileState(TileState state)
    {
        tileState = state;
    }
    public TileState GetTileState()
    {
        return tileState;
    }

}
