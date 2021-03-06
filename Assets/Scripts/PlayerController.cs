﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject m_Player;
    public Rigidbody2D m_PlayerRB;
    public InputField m_InputField;

    public GameObject m_HelpOptions;

    private float m_JumpForce = 6.5f;
    private float m_Speed = 5f;

    public bool m_MoveLeft = false;
    public bool m_MoveRight = false;

    private void Awake() {
        m_HelpOptions.SetActive(false);
    }

    private void Update()
    {
        GUIUtility.systemCopyBuffer = null;
        
        if(m_InputField.isFocused == false)
            m_InputField.ActivateInputField();

        if (m_InputField.text != null && Input.GetKeyDown(KeyCode.Return))
        {
            ProccessInput(m_InputField.text);
            m_InputField.text = null;
        }

        MoveLeft();
        MoveRight();
    }

    public void ProccessInput(string text)
    {
        if (text == "jump")
            Jump();

        if (text == "jump left")
            JumpLeft();

        if (text == "jump right")
            JumpRight();

        if (text == "left")
        {
            m_MoveLeft = true;
            m_MoveRight = false;
        }

        if (text == "right")
        {
            m_MoveRight = true;
            m_MoveLeft = false;
        }

        if(text == "stop")
        {
            m_MoveLeft = false;
            m_MoveRight = false;
            m_PlayerRB.velocity = Vector3.zero;
        }

        if (text == "restart")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (text == "exit")
            SceneManager.LoadScene("menu");
        if(text == "help")
            m_HelpOptions.SetActive(true);
    }

    private void MoveLeft()
    {
        if (m_MoveLeft)
            m_PlayerRB.velocity = new Vector2(-m_Speed, m_PlayerRB.velocity.y);
    }

    private void MoveRight()
    {
        if (m_MoveRight)
            m_PlayerRB.velocity = new Vector2(m_Speed, m_PlayerRB.velocity.y);
    }

    private void Jump()
    {
        m_PlayerRB.AddForce(new Vector2(0, m_JumpForce), ForceMode2D.Impulse);
    }

    private void JumpLeft()
    {
        m_PlayerRB.AddForce(new Vector2(-m_JumpForce/2f, m_JumpForce), ForceMode2D.Impulse);
    }

    private void JumpRight()
    {
        m_PlayerRB.AddForce(new Vector2(m_JumpForce/2f, m_JumpForce), ForceMode2D.Impulse);
    }

    public void CloseHelp(){
        m_HelpOptions.SetActive(false);
    }
}
