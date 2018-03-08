using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocking : MonoBehaviour {

    [SerializeField]
    private GameObject m_Shield;

    [SerializeField]
    private bool m_Player1;

    [SerializeField]
    private Health m_Player;

    [SerializeField]
    private float m_Delay, m_DelaySpeed, m_DelayFadeSpeed, m_CounterDelay, m_MaxCounterDelay, m_CounterDelaySpeed;

    private float m_MaxDelay;

    [SerializeField]
    private Slider m_ShieldBar;

    private bool m_Stop, m_Shielded;

    [SerializeField]
    private Image m_BlockFill;

    private Color m_MainColor;

    [SerializeField]
    private Health m_OtherHealth;

    // Use this for initialization
    void Start ()
    {
        m_MaxDelay = m_Delay;
        m_Delay = 0;

        m_MaxCounterDelay = m_CounterDelay;

        m_MainColor = m_BlockFill.color;
    }
	
	// Update is called once per frame
	void Update () {
        m_Shield.active = false;
        m_Player.Blocking(false);

        m_ShieldBar.maxValue = m_MaxDelay;
        m_ShieldBar.value = m_Delay;

        m_Shielded = false;

        if (m_Player1)
        {
            if (Input.GetKey(KeyCode.W) && m_Delay <= m_MaxDelay && !m_Stop)
            {
                m_Shield.active = true;
                m_Player.Blocking(true);
                m_Shielded = true;

                m_CounterDelay = m_MaxCounterDelay;

                if (m_Delay < m_MaxDelay)
                {
                    m_Delay += m_DelaySpeed * Time.deltaTime;
                }

                if (m_Delay >= m_MaxDelay)
                {
                    m_Stop = true;
                    m_BlockFill.color = Color.red;
                }
            }

            else
            {
                m_Stop = true;
                m_BlockFill.color = Color.red;
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.UpArrow) && m_Delay <= m_MaxDelay && !m_Stop)
            {
                m_Shield.active = true;
                m_Player.Blocking(true);
                m_Shielded = true;

                m_CounterDelay = m_MaxCounterDelay;

                if (m_Delay < m_MaxDelay)
                {
                    m_Delay += m_DelaySpeed * Time.deltaTime;
                }

                if (m_Delay >= m_MaxDelay)
                {
                    m_Stop = true;
                    m_BlockFill.color = Color.red;
                }
            }

            else
            {
                m_Stop = true;
                m_BlockFill.color = Color.red;
            }
        }

        if (m_Delay > 0 && !m_Shielded)
        {
            m_Delay -= m_DelayFadeSpeed * Time.deltaTime;
        }

        if (m_Delay <= 0)
        {
            m_Stop = false;
            m_BlockFill.color = m_MainColor;
        }
        else
        {
            m_ShieldBar.gameObject.active = true;
        }

        if (m_CounterDelay > 0)
        {
            m_CounterDelay -= m_CounterDelaySpeed * Time.deltaTime;
        }
    }
}
