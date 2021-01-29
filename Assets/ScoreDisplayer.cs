using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    public TextMeshProUGUI enemy_score;
    public TextMeshProUGUI ally_score;
    public TextMeshProUGUI player_score;
   
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        enemy_score.SetText(GameStartController.GSC.gameStats.enemyScore.ToString());
        ally_score.SetText(GameStartController.GSC.gameStats.allyScore.ToString());
        player_score.SetText(GameStartController.GSC.gameStats.playerScore.ToString());
    }
}
