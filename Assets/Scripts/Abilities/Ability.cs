using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateAbility",fileName = "newAbility")]
public class Ability : ScriptableObject
{
    public Sprite AbilityImage;


    public virtual void CastAbility()
    {
        Debug.Log("[System] : Base Class for Abilities");
    }
}
