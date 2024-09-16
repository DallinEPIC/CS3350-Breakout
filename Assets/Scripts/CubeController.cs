using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Color color;
    public Vector3 StartPosition, StartScale;
    public float Speed;
    public GameObject MaxPositionX;
    public GameObject MinPositionX;
    void Start()
    {
        transform.position = StartPosition;
        transform.localScale = StartScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) 
            && transform.position.x - StartScale.x /2f > MinPositionX.transform.position.x)
            transform.position += Vector3.left * Time.deltaTime * Speed;
        if (Input.GetKey(KeyCode.RightArrow) 
            && transform.position.x + StartScale.x /2f < MaxPositionX.transform.position.x)
            transform.position += Vector3.right * Time.deltaTime * Speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().color = color;
            Debug.Log("Hello");
        }
    }
}
