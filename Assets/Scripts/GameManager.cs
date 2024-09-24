using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public bool GameRunning;
    public GameObject BallPrefab;
    public float RespawnTimer;
    [SerializeField] [Range(0,15)] private int _maxRespawns;
    private int _respawnCount;
    [SerializeField] private GameObject _losePanel;

    [SerializeField] private TextMeshProUGUI _ballText;

    // Start is called before the first frame update
    void Start()
    {
        _losePanel.SetActive(false); 
        GameRunning = true;
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
        else
        {
            GameRunning = false;
            _losePanel.SetActive(true);
        }
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
