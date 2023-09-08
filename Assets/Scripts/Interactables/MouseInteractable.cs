using System.Collections.Generic;
using UnityEngine;

public enum ObjectHighlight
{
    GREEN, // CommonItems
    BLUE, // RareItems
    YELLOW, // KeyItems
    PURPLE // MythicItems
}

public class MouseInteractable : Interactable
{
    [Header("Container Rarity")]
    [SerializeField] protected ObjectHighlight objectHighlights = ObjectHighlight.GREEN;
    protected readonly List<Color> HighlightedColor = new List<Color>();
    protected readonly Color DisabledColor = Color.red;
    protected MeshRenderer mr;

    private void OnEnable()
    {
        HighlightedColor.Clear();
        HighlightedColor.Add(Color.green);
        HighlightedColor.Add(Color.blue);
        HighlightedColor.Add(Color.yellow);
        HighlightedColor.Add(Color.magenta);
    }

    public virtual void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }
    public virtual void OnMouseOver()
    {
        mr.material.color = PlayerInRange() ? HighlightedColor[(int)objectHighlights] : DisabledColor;

        if (Input.GetMouseButtonDown(0) && PlayerInRange())
        {
            Interact();
        }
    }

    public virtual void OnMouseExit()
    {
        mr.material.color = Color.white;
    }

    public override void Interact()
    {
        Debug.Log("This is the [MouseInteractable] Class for Interactable Objects");
    }
}
