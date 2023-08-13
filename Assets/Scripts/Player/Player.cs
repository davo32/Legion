using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NovaUtils;
using TMPro;

public class Player : MonoBehaviour
{
    public PlayerData playerData = new PlayerData(100);
    [SerializeField] private TextMeshProUGUI MoveText;
    [SerializeField] private GameObject currTile;
    public float walkDistance = 1.0f;


    private void Start()
    {
        playerData.SetCurrentTile(currTile);
        currTile.GetComponent<Tile>().Data.SetTileState(TileState.CURRENTTILE);
    }

    public bool CheckInDistance(Vector3 other, float value)
    {
        float temp = NovaUtilities.Vector3Distance(playerData.GetCurrentTile().transform.position, other);
        Debug.Log($"Distance: {temp}");
        if (temp <= value) return true;
        else if (temp > value) return false;
        else return false;

    }

    private void Update()
    {
        MoveText.text = playerData.GetAllowedMoves().ToString();
    }
}
