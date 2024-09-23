using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject BallPrefab;
    public float RespawnTimer;
    [SerializeField] [Range(0,15)] private int _maxRespawns;
    private int _respawnCount;

    [SerializeField] private TextMeshProUGUI _ballText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(BallPrefab);
        Instance = this;
        UpdateBallText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BallOutOfBounds(GameObject ball)
    {
        Destroy(ball);

        if (_respawnCount < _maxRespawns)
            StartCoroutine(WaitAndRespawn());
    }
    private IEnumerator WaitAndRespawn()
    {
        yield return new WaitForSeconds(RespawnTimer);
        GameObject ballObject = Instantiate(BallPrefab);
        _respawnCount++;
        UpdateBallText();
    }

    private void UpdateBallText()
    {
        _ballText.text = "Balls Remaining: " + (_maxRespawns - _respawnCount) + "/" + _maxRespawns;
    }
}
