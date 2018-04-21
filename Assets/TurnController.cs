using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TurnController : MonoBehaviour {

    public FirstPersonController player1;
    public FirstPersonController player2;
    private int turnCounter = 0;
    private float p_DefaultSpeed;
    private float P_DefaultJumpSpeed;
    private float p_DefaultXSens;
    private float p_DefaultYSens;
    private int noPlayers;
    private float turnLength;
    private bool turn;

    private void Start()
    {
        p_DefaultSpeed = player1.m_WalkSpeed;
        P_DefaultJumpSpeed = player1.m_JumpSpeed;
        p_DefaultXSens = player1.m_MouseLook.XSensitivity;
        p_DefaultYSens = player1.m_MouseLook.YSensitivity;
        player1.m_WalkSpeed = 0;
        noPlayers = 2;
        player2.m_WalkSpeed = 0;
        turnLength = 5;
        turn = false;
    }

    private void Main()
    {
        Turn();
    }

    private void Turn(FirstPersonController currentPlayer)
    {
        float time_remaining = turnLength;

        while (turn)
        {

            startPlayer(currentPlayer);

            time_remaining -= Time.deltaTime;

            if (time_remaining <= 0) {

                turn = false;
                stopPlayer(currentPlayer);
                // Broadcast turn has ended

            };

        }
        // Do all the turn stuff


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