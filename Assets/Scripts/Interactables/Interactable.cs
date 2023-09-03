using UnityEngine;
public class Interactable : MonoBehaviour
{
    public bool PlayerInRange(float value = 1.0f)
    {
        float temp = Vector3.Distance(GameManager.Instance.PlayerActiveUnit.GetCurrentTile().transform.position, transform.position);
        if (temp <= value) return true;
        else return false;
    }
    
    public virtual void Interact()
    {
        Debug.Log("This is the [base] Class for Interactable Objects");
    }
}
