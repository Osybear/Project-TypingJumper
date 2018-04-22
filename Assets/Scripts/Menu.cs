using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject m_Levels;
    public GameObject m_Controls;
    public GameObject m_MainMenu;

    private void Awake()
    {
        m_Levels.SetActive(false);
        m_Controls.SetActive(false);
    }

    public void OpenLevels()
    {
        m_MainMenu.SetActive(false);
        m_Levels.SetActive(true);
    }

    public void OpenControls()
    {
        m_MainMenu.SetActive(false);
        m_Controls.SetActive(true);
    }

    public void MainMenu()
    {
        m_Controls.SetActive(false);
        m_Levels.SetActive(false);
        m_MainMenu.SetActive(true);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name); 
    }
}
