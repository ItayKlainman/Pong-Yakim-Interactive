using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI opponentScore, playerScore;
    [SerializeField] private Button startButton;
    
    public void ResetUI()
    {
        startButton.gameObject.SetActive(true);
        UpdateUIScore(ScoreSides.Player, 0);
        UpdateUIScore(ScoreSides.Opponent, 0);
        
    }

    public void UpdateUIScore(ScoreSides side, int score)
    {
        var text = side == ScoreSides.Player ? playerScore : opponentScore;
        text.SetText(score.ToString("N0"));
    }
}