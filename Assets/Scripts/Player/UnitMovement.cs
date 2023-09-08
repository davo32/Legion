using System;
using Unity.VisualScripting;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    //1 Tile = 1.0f ratio 1:1
    public float walkDistance = 1.0f;
    private float _speed = 4.0f;

    public bool isMoving = false;
    //checks to see if the unit can move 
    public bool canMove;

    //Current tile unit is on
    private Tile _currTile;
    public Tile targetTile;

    private Vector3 targetPos;

    private void Start()
    {
        //Sets the current Tile when unit is spawned
        RaycastHit hit;
        LayerMask layermask = LayerMask.GetMask("Tile");

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layermask))
        {
            if (hit.collider.CompareTag("Tile"))
            {
                _currTile = hit.collider.gameObject.GetComponent<Tile>();
                SetCurrentTile(_currTile.gameObject);
                _currTile.Data.SetTileState(TileState.CURRENTTILE);
            }
        }
        /////////////////////////////////////////////////

        
    }

    public void SetCurrentTile(GameObject tile)
    {
        _currTile = tile.GetComponent<Tile>();
    }
    public Tile GetCurrentTile()
    {
        return _currTile;
    }

    //used in movement - It checks the distance between the Unit's Current Tile to the chosen tile
    public bool CheckInDistance(Vector3 other, float value = 1.5f)
    {
        float temp = Vector3.Distance(GameManager.Instance.PlayerActiveUnit.GetCurrentTile().transform.position, other);
        Debug.Log($"Distance: {temp}");
        if (temp <= value) return true;
        else return false;
    }
    /////////////////////////////////////////////////////

    private void Update()
    {
        if (isMoving)
        {
            var step = _speed * Time.deltaTime;

            targetPos = new Vector3(targetTile.transform.position.x, targetTile.transform.position.y + 0.66f, targetTile.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            if (Vector3.Distance(transform.position, targetPos) < 0.001f)
            {
                isMoving = false;
                _currTile.Data.SetTileState(TileState.UNOCCUPIED);
                SetCurrentTile(targetTile.gameObject);
                targetTile.Data.SetTileState(TileState.CURRENTTILE);
            }
        }
    }
    
}
