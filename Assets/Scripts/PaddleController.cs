using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PaddleController : MonoBehaviour
{
    public Vector3 StartPosition, StartScale;
    public float Speed;
    public GameObject MaxPosition, MinPosition;
    public static PaddleController Instance;
    void Start()
    {
        Instance = this;
        transform.position = StartPosition;
        transform.localScale = StartScale;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) 
            && transform.position.x - StartScale.x /2f > MinPosition.transform.position.x)
            transform.position += Vector3.left * Time.deltaTime * Speed;
        if (Input.GetKey(KeyCode.RightArrow) 
            && transform.position.x + StartScale.x /2f < MaxPosition.transform.position.x)
            transform.position += Vector3.right * Time.deltaTime * Speed;
    }
}
