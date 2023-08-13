using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GridSquare Data = new GridSquare();

    public TextMeshPro MoveAddIndicator;
    public TileType _tileType;
    private Player Player;
    private GameObject TileCentre;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        TileCentre = gameObject.transform.GetChild(0).gameObject;
        Data.SetTileType(_tileType);

        switch (Data.GetTileType())
        {
            case TileType.NORMAL:
                {
                    MoveAddIndicator.gameObject.SetActive(false);
                    break;
                }
            case TileType.PICKUP:
                {
                    MoveAddIndicator.gameObject.SetActive(true);
                    MoveAddIndicator.text = Data.GetMovesToAdd().ToString();
                    break;
                }
        }
    }

    void MoveToTile()
    {
        Debug.Log($"Distance: {Player.GetComponent<Player>().CheckInDistance(gameObject.transform.position, Player.walkDistance)}");
        
        if (Player.playerData.GetAllowedMoves() > 0)
        {
            if (Player.CheckInDistance(this.transform.position, Player.walkDistance))
            {
                Player.playerData.GetCurrentTile().Data.SetTileState(TileState.UNOCCUPIED);
                Player.transform.position = new Vector3(this.transform.position.x, Player.transform.position.y, this.transform.position.z);
                Player.playerData.SetCurrentTile(this.gameObject);
                Player.playerData.GetCurrentTile().Data.SetTileState(TileState.CURRENTTILE);
                Player.playerData.GetCurrentTile().Data.TypeLogic(Player, this);
                Player.playerData.AddAllowedMoves(-1);
            }
        }
    }

   
    private void OnMouseOver()
    {
        TileCentre.GetComponent<MeshRenderer>().material.color = Data.StateLogic(Player,this.gameObject);

        if (Input.GetMouseButtonUp(0))
        {
            MoveToTile();
        }
    }

    private void OnMouseExit()
    {
        TileCentre.GetComponent<MeshRenderer>().material.color = Color.black;
    }

   
}
