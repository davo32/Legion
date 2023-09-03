using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityState
{ 
    NONE,
    READY,
    CASTING,
    COOLDOWN
}

//Ability Holder
public class AbilityCard : MonoBehaviour
{
    public Ability ability;
    public AbilityState abilityState = AbilityState.NONE;
    [SerializeField] KeyCode HotKey;


    private void Update()
    {
        if (ability == null)
            return;

        if (Input.GetKeyDown(HotKey))
        {
            switch (abilityState)
            {
                case AbilityState.NONE:
                    {
                        Debug.LogWarning("No ability Assigned!");
                        break;
                    }
                case AbilityState.READY:
                    {
                        Debug.Log($"{ability.name} : READY!");
                        break;
                    }
                case AbilityState.CASTING: 
                    {
                        Debug.Log($"{ability.name} : CASTING!");
                        break;
                    }
                case AbilityState.COOLDOWN:
                    {
                        Debug.Log($"{ability.name} : COOLDOWN!");
                        break;
                    }
            }
        }
    }
}
