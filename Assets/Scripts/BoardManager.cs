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
    }

    public void StartGame()
    {
        ResetScore();
        ballController.LaunchBall();
        uiController.ResetUI();
    }

    private void HandleScore(ScoreSides side)
    {
        switch (side)
        {
            case ScoreSides.Player :
                playerScore++;
                break;
            case ScoreSides.Opponent :
                opponentScore++;
                break;
        }

        CheckScoreStatus(side);
    }

    private void CheckScoreStatus(ScoreSides side)
    {
        if (playerScore >= scoreLimit || opponentScore >= scoreLimit)
        {
            RestartGame();
        }

        var score = side == ScoreSides.Player ? playerScore : opponentScore;
        
        uiController.UpdateUIScore(side, score);
    }

    private void RestartGame()
    {
        ResetScore();
        SceneManager.LoadScene(0);
    }

    private void ResetScore()
    {
        playerScore = 0;
        opponentScore = 0;
    }
}

//Decided to make the sides enum instead of using a bool or int for clarity's sake. 
public enum ScoreSides
{
    Player,
    Opponent
}