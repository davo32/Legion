using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData Data = new TileData();

    public TileType _tileType;
    private Unit OccupiedUnit;
    private GameObject TileCentre;

    private void Awake()
    {
        TileCentre = gameObject.transform.GetChild(0).gameObject;

        RaycastHit hit;
        LayerMask layermask = LayerMask.GetMask("Unit");

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, layermask))
        {
            if (hit.collider.CompareTag("Unit"))
            {
                OccupiedUnit = hit.collider.gameObject.GetComponent<Unit>();
            }
        }

        Data.SetTileType(_tileType);
        switch (Data.GetTileType())
        {
            case TileType.NORMAL:
                {
                    break;
                }
            case TileType.PICKUP:
                {
                    break;
                }
        }
    }

    void MoveToTile()
    {
        //checks to see if Occupied Unit exists
        //Checks to see if the Occupied Unit can move
        if (OccupiedUnit == null || !OccupiedUnit.canMove) 
            return;
        
        Debug.Log($"Distance: {OccupiedUnit.GetComponent<Unit>().CheckInDistance(gameObject.transform.position, OccupiedUnit.walkDistance)}");

        if (OccupiedUnit.CheckInDistance(this.transform.position, OccupiedUnit.walkDistance))
        {
          OccupiedUnit.unitData.GetCurrentTile().Data.SetTileState(TileState.UNOCCUPIED);
          OccupiedUnit.transform.position = new Vector3(this.transform.position.x, OccupiedUnit.transform.position.y, this.transform.position.z);
          OccupiedUnit.unitData.SetCurrentTile(this.gameObject);
          OccupiedUnit.unitData.GetCurrentTile().Data.SetTileState(TileState.CURRENTTILE);
          OccupiedUnit.unitData.GetCurrentTile().Data.TypeLogic(OccupiedUnit, this);
          OccupiedUnit.canMove = false;
        }
    }

   
    private void OnMouseOver()
    {
        TileCentre.GetComponent<MeshRenderer>().material.color = Data.StateLogic(OccupiedUnit,this.gameObject);

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
