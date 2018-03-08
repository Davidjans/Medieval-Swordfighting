using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private string m_SceneName;
    public void OnClick()
    {
        if(m_SceneName == "Exit")
        {
            Application.Quit();
        }
        SceneManager.LoadScene(m_SceneName);
    }
}
