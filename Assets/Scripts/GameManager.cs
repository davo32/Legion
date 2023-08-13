using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        { 
            Instance = this;
        }

    }

    //Active Player Unit
    public Unit PlayerActiveUnit;
    // Player's Units in Play
    public List<Unit> PlayerCurrentUnits = new List<Unit>();
    //Active Enemy Unit




}
