using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private BallController ballController;
    [SerializeField] private int scoreLimit;

    private int playerScore, opponentScore;

    private void Start()
    {
        ballController.InitBall(HandleScore);
        uiController.Init(delegate
        {
            playerScore = 0;
            opponentScore = 0;
            ballController.LaunchBall();
        });
    }

    private void HandleScore(ScoreSides side)
    {
        var score = side == ScoreSides.Player ? playerScore : opponentScore;
        score++;

        if (side == ScoreSides.Player)
        {
            playerScore++;
        }
        else
        {
            opponentScore++;
        }

        if (score >= scoreLimit)
        {
            RestartGame();
        }

        uiController.UpdateUIScore(side, score);
    }

    private void RestartGame()
    {
        playerScore = 0;
        opponentScore = 0;

        SceneManager.LoadScene(0);
    }
}

//Decided to make the sides enum instead of using a bool or int for clarity's sake. 
public enum ScoreSides
{
    Player,
    Opponent
}