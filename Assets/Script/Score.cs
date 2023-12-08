using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{

    public GameManager manager;
    public Text scoreText;
    void Update()
    {
        scoreText.text=manager.score.ToString();
    }
}
