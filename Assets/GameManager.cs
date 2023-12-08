using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{
    public Ball ball { set;private get; }
    public paddle paddle { set;private get; }
    public Brick[] bricks { set; private get; }
    public int level = 1;
    public int score = 0;
    public int lives = 3;

    public Text liveText;
    public Text scoreText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevel(1);
        
    }
    public void LoadLevel(int level)
    {
        this.level = level;
        
        if (level > 10 )
        {
            SceneManager.LoadScene("WinScreen");
        }
        else 
        {
            SceneManager.LoadScene("Level" + level);
        }

        
    }
    public void playAgain()
    {
        SceneManager.LoadScene("Level" + level);
    }

    private void gameOver()
    {
        SceneManager.LoadScene("GameOver");
        this.lives = 3;
    }
    public void resetLevel()
    {
        this.ball.Resetball();
        this.paddle.Resetpaddle();
        liveText.text = "Lives : " + lives;
    }
    public void Miss()
    {
        this.lives--;
        liveText.text = "Lives : " + lives;
        if (this.lives > 0)
        { 
            resetLevel();
        }
        else
        {
            gameOver();
        }
    }
    public void OnLevelLoaded(Scene scene,LoadSceneMode mode)
    {
        this.ball=FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<paddle>();
        this.bricks= FindObjectsOfType<Brick>();
    }
    public void Hit(Brick brick)
    {
        this.score += brick.points;
        scoreText.text = "Score : " + score;
        if (cleard())
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
    public void next()
    {
        LoadLevel(level + 1);
    }
    private bool cleard()
    {
        for(int i=0; i<this.bricks.Length;i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbrakable)
            {
                return false;
            }
        }
        return true;
    }
}
