using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public TurnController tc;
    public RoundController rc;
    private GameObject winner;
    private int p1_score;
    private int p2_score;
    public Text p1_score_text;
    public Text p2_score_text;

    private void Start()
    {
        p1_score = 0;
        p2_score = 0;
        p1_score_text.text = p1_score.ToString();
        p2_score_text.text = p2_score.ToString();
    }

    public void startNextRound() {

        winner = tc.currentPlayer.gameObject;

        tc.running = false;
        rc.nextRound = true;
        AddScore();
        tc.stopPlayer(tc.currentPlayer);
        rc.timeRemainingText.gameObject.SetActive(true);
        rc.resetGame();
        rc.positioning_period_time_remaining = rc.positioning_period_time;
        rc.nextRound = true;

    }

    public void AddScore (){

        if(winner == tc.player1.gameObject)
        {
            p1_score++;
            p1_score_text.text = p1_score.ToString();
        } else
        {
            p2_score++;
            p2_score_text.text = p2_score.ToString();
        }

    }

}
