using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Vector3 Velocity;
    private PaddleController _paddle;
    [SerializeField] public float _maxHorizontalSpeed;

    private Vector3 _paddleSize, _paddlePos, _ballSize, _ballPos;

    void Start()
    {
        Velocity = Vector3.down;
    }

    void Update()
    {
        _paddleSize = PaddleController.Instance.transform.localScale;
        _paddlePos = PaddleController.Instance.transform.position;
        _ballSize = transform.localScale;
        _ballPos = transform.position;

        if (_ballPos.x + _ballSize.x / 2f >= _paddlePos.x - _paddleSize.x / 2f &&
            _ballPos.x - _ballSize.x / 2f <= _paddlePos.x + _paddleSize.x / 2f &&
            _ballPos.y + _ballSize.y / 2f >= _paddlePos.y - _paddleSize.y / 2f &&
            _ballPos.y - _ballSize.y / 2f <= _paddlePos.y + _paddleSize.y / 2f
            )
        {
            Velocity.y = -Velocity.y;
            Velocity.x = UnityEngine.Random.Range(-_maxHorizontalSpeed, _maxHorizontalSpeed);
        }

        if (_ballPos.x + _ballSize.x / 2f > PaddleController.Instance.MaxPosition.transform.position.x ||
            _ballPos.x - _ballSize.x / 2f < PaddleController.Instance.MinPosition.transform.position.x)
        {
            Velocity.x = -Velocity.x;
        }


        if (_ballPos.y + _ballSize.y / 2f > PaddleController.Instance.MaxPosition.transform.position.y)
        {
            Velocity.y = -Velocity.y;
        }

        transform.position += Velocity * Time.deltaTime;
    }
}
