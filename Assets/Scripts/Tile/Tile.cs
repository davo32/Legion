using System;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData Data = new TileData();
    
    public TileType _tileType;
    private UnitMovement OccupiedUnit;
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
                OccupiedUnit = hit.collider.gameObject.GetComponent<UnitMovement>();
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
        if (OccupiedUnit == null || !OccupiedUnit.canMove /*|| OccupiedUnit.unitData.GetCurrentTile().Data.GetTileState() == TileState.CURRENTTILE*/) 
            return;
        

        if (OccupiedUnit.CheckInDistance(this.transform.position, OccupiedUnit.walkDistance))
        {
          OccupiedUnit.isMoving = true;
          OccupiedUnit.targetTile = this;
          
        }
    }

   
    private void OnMouseOver()
    {
        OccupiedUnit = GameManager.Instance.PlayerActiveUnit;
        
        TileCentre.SetActive(true);
        TileCentre.GetComponent<MeshRenderer>().material.color = Data.StateLogic(OccupiedUnit,this.gameObject);

        if (Input.GetMouseButtonDown(0) && Data.GetTileState() == TileState.UNOCCUPIED)
        {
            MoveToTile();
        }
    }

    private void OnMouseExit()
    {
        TileCentre.GetComponent<MeshRenderer>().material.color = Color.black;
        TileCentre.SetActive(false);
    }

    
}
