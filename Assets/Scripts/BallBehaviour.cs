using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Vector3 _velocity;
    public float Speed;
    void Start()
    {
        _velocity = Vector3.down;
        Speed = 10;
    }

    void Update()
    {
        transform.position += _velocity * Speed * Time.deltaTime;
    }
}
