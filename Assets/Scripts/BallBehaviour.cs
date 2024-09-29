using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] public Vector3 Velocity;
    [SerializeField] public float _maxHorizontalSpeed;
    private PaddleController _paddle;

    private Vector3 _ballSize, _ballPos;

    void Start()
    {
        Velocity = Vector3.down * 5;
    }

    void Update()
    {
        if (!GameManager.Instance.GameRunning) return;

        _ballSize = transform.localScale;
        _ballPos = transform.position;

        if (CollidesWithGameObject(PaddleController.Instance.gameObject))
        {
            Velocity.y = -Velocity.y;
            Vector3 PaddleToBall = transform.position - PaddleController.Instance.transform.position;
            Velocity.x = PaddleToBall.x * _maxHorizontalSpeed;
        }

        for(int i = 0; i < GameManager.Instance.Bricks.Length; i++)
        {
            if (GameManager.Instance.Bricks[i] != null && CollidesWithGameObject(GameManager.Instance.Bricks[i]))
            {
                Destroy(GameManager.Instance.Bricks[i]);
                GameManager.Instance.Bricks[i] = null;
                GameManager.Instance.CheckForWin();
                Velocity.y = -Velocity.y;
                break;
            }
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

        if (_ballPos.y + _ballSize.y / 2f < PaddleController.Instance.MinPosition.transform.position.y)
        {
            GameManager.Instance.BallOutOfBounds(gameObject);
        }

        transform.position += Velocity * Time.deltaTime;
    }

    private bool CollidesWithGameObject(GameObject go)
    {
        return
            _ballPos.x + _ballSize.x / 2f >= go.transform.position.x - go.transform.localScale.x / 2f &&
            _ballPos.x - _ballSize.x / 2f <= go.transform.position.x + go.transform.localScale.x / 2f &&
            _ballPos.y + _ballSize.y / 2f >= go.transform.position.y - go.transform.localScale.y / 2f &&
            _ballPos.y - _ballSize.y / 2f <= go.transform.position.y + go.transform.localScale.y / 2f;
    }
}
