using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

    public GameObject m_YouWin;
    public PlayerController m_PlayerController;

    private void Awake()
    {
        m_YouWin.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_YouWin.SetActive(true);
        m_PlayerController.ProccessInput("stop");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
