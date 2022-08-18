using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] GameObject gameOverUI;
    private float difficultyTimer = 10.2f;
    private static long bestScore;
    private float timer;
    private float scoreTimer;
    private long score;
    private int scoreIncrease;
    private bool gameOver;
    public float GameSpeed { get; private set; }
    void Start()
    {
        scoreIncrease = 1;
        GameSpeed = 5f;
        bestScoreText.text = "Best Score: " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;
        timer += Time.deltaTime;
        scoreTimer += Time.deltaTime;
        if (scoreTimer > 1f)
        {
            score += scoreIncrease;
            scoreTimer = 0;            
        }
        if (timer > difficultyTimer)
        {
            scoreIncrease++;
            GameSpeed *= 1.2f;
            timer = 0;
        }
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        if (bestScore < score)
            bestScore = score;
        gameOver = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
