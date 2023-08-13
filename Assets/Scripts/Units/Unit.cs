using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NovaUtils;
using TMPro;

public class Unit : MonoBehaviour
{
    
    //HP-DEF-ATK etc..
    public UnitData unitData;
    //1 Tile = 1.0f ratio 1:1
    public float walkDistance = 1.0f;
    //checks to see if the unit can move 
    public bool canMove;

    //Current tile unit is on
    [SerializeField] private GameObject currTile;
    


    private void Start()
    {
        //Sets the current Tile when unit is spawned
        RaycastHit hit;
        LayerMask layermask = LayerMask.GetMask("Tile");

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask))
        {
            if (hit.collider.CompareTag("Tile"))
            {
                currTile = hit.collider.gameObject;
                unitData.SetCurrentTile(currTile);
                currTile.GetComponent<Tile>().Data.SetTileState(TileState.CURRENTTILE);
            }
        }
        /////////////////////////////////////////////////

        
    }
    //used in movement - It checks the distance between the Unit's Current Tile to the chosen tile
    public bool CheckInDistance(Vector3 other, float value)
    {
        float temp = NovaUtilities.Vector3Distance(GameManager.Instance.PlayerActiveUnit.unitData.GetCurrentTile().transform.position, other);
        Debug.Log($"Distance: {temp}");
        if (temp <= value) return true;
        else return false;
    }
    /////////////////////////////////////////////////////
    
}
