using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] private Text m_ScorePlayer1Text, m_ScorePlayer2Text;
    private int m_ScorePlayer1, m_ScorePlayer2;
    [SerializeField] private int m_MaxScore;

    [SerializeField] private Text m_Winner;
    [SerializeField] private GameObject m_Win;

    // Use this for initialization
    void Start () {
        m_ScorePlayer1 = PlayerPrefs.GetInt("Player1");
        m_ScorePlayer2 = PlayerPrefs.GetInt("Player2");
    }

    public void AddPlayer1Score()
    {
        m_ScorePlayer1++;

        m_Win.SetActive(true);
        m_Winner.enabled = true;

        if (m_ScorePlayer1 < m_MaxScore)
        {
            m_Winner.text = "Player 1 wins this round!";
        }

        else
        {
            m_Winner.text = "Player 1 wins the game!";
        }
    }

    public void AddPlayer2Score()
    {
        m_ScorePlayer2++;

        m_Win.SetActive(true);
        m_Winner.enabled = true;

        if (m_ScorePlayer2 < m_MaxScore)
        {
            m_Winner.text = "Player 2 wins this round!";
        }

        else
        {
            m_Winner.text = "Player 2 wins the game!";
        }
    }

    // Update is called once per frame
    void Update () {
        m_ScorePlayer1Text.text = m_ScorePlayer1 + "";
        m_ScorePlayer2Text.text = m_ScorePlayer2 + "";

        PlayerPrefs.SetInt("Player1", m_ScorePlayer1);
        PlayerPrefs.SetInt("Player2", m_ScorePlayer2);

        if (m_ScorePlayer1 >= m_MaxScore)
        {
            PlayerPrefs.SetInt("Player1", 0);
            PlayerPrefs.SetInt("Player2", 0);
        }

        else if (m_ScorePlayer2 >= m_MaxScore)
        {
            PlayerPrefs.SetInt("Player1", 0);
            PlayerPrefs.SetInt("Player2", 0);
        }
    }
}
