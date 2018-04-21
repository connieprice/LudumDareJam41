using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class TurnController : MonoBehaviour {

    public FirstPersonController player1;
    public FirstPersonController player2;
    private int turnCounter = 0;
    private float p_DefaultSpeed;
    private float P_DefaultJumpSpeed;
    private float p_DefaultXSens;
    private float p_DefaultYSens;
    private float turnLength;
    public Text timeRemainingText;
    private float time_remaining;
    private FirstPersonController currentPlayer;
    private bool changePlayer = true;

    private void Start()
    {
        p_DefaultSpeed = player1.m_WalkSpeed;
        P_DefaultJumpSpeed = player1.m_JumpSpeed;
        p_DefaultXSens = player1.m_MouseLook.XSensitivity;
        p_DefaultYSens = player1.m_MouseLook.YSensitivity;
        player1.m_WalkSpeed = 0f;
        player2.m_WalkSpeed = 0f;
        player1.m_RunSpeed = 0f;
        player2.m_RunSpeed = 0f;
        player1.m_JumpSpeed = 0f;
        player2.m_JumpSpeed = 0f;
        turnLength = 5f;
        time_remaining = turnLength;
        currentPlayer = player2;
    }

    private void Update()
    {

        if (!changePlayer)
        {
            timeRemainingText.text = ((int) time_remaining+1).ToString();
            time_remaining -= Time.deltaTime;

            if(time_remaining <= 0f)
            {
                stopPlayer(currentPlayer);
                changePlayer = true;
            }
        } else
        {
            if(currentPlayer == player1)
            {
                currentPlayer = player2;
            } else
            {
                currentPlayer = player1;
            }

            startPlayer(currentPlayer);
            changePlayer = false;
            time_remaining = turnLength;
        }

    }

    public void startPlayer(FirstPersonController player) {

        player.m_WalkSpeed = p_DefaultSpeed;
        player.m_RunSpeed = p_DefaultSpeed;
        player.m_JumpSpeed = P_DefaultJumpSpeed;
        player.m_MouseLook.XSensitivity = p_DefaultXSens;
        player.m_MouseLook.XSensitivity = p_DefaultYSens;

    }

    public void stopPlayer (FirstPersonController player){

        player.m_WalkSpeed = 0f;
        player.m_RunSpeed = 0f;
        player.m_JumpSpeed = 0f;
        player.m_MouseLook.XSensitivity = 0f;
        player.m_MouseLook.XSensitivity = 0f;

    }
}