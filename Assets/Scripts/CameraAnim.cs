using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour {

    public Animator m_Animator;
    public PlayerController m_PlayerController;

    private void Awake()
    {
        m_PlayerController.m_InputField.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Animator.Play("Transition", 0, 1);
        }    
    }

    public void EnableInput()
    {
        m_PlayerController.m_InputField.gameObject.SetActive(true);
        m_PlayerController.m_InputField.ActivateInputField();
    }
}
