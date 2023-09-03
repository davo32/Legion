using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    private float moveSpeed = 1.0f;
    private Vector3 target01;
    private Vector3 target02;
    private Vector3 Active;

    private bool swap = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        target01 = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
        target01 = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
        var step = moveSpeed * Time.deltaTime;

        Active = swap ? target01 : target02;
        transform.position = Vector3.MoveTowards(transform.position, Active, step);

        if (Vector3.Distance(transform.position, Active) < 0.001f)
        {
            Debug.Log("Arrived!");
            swap = !swap;
        }
    }
}
