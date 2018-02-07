using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacking : MonoBehaviour
{

    [SerializeField]
    private BoxCollider m_Sword;

    private bool m_Attack;

    [SerializeField]
    private Vector3 m_AttackSpeed;

    [SerializeField]
    private float m_Delay, m_DelaySpeed;

    private float m_MaxDelay;

    [SerializeField]
    private Health m_OtherHealth;

    [SerializeField]
    private bool m_Player1;

    [SerializeField]
    private Slider m_AttackBar;

    // Use this for initialization
    void Start()
    {
        m_MaxDelay = m_Delay;
    }

    public void OnTriggerEnter(Collider other)
    {
        m_OtherHealth.TakingDamage();
    }

    // Update is called once per frame
    void Update()
    {
        m_AttackBar.maxValue = m_MaxDelay;
        m_AttackBar.value = m_Delay;

        if (m_AttackBar.value < m_MaxDelay)
        {
            m_AttackBar.gameObject.active = true;
        }

        else
        {
            m_AttackBar.gameObject.active = false;
        }

        if (m_Delay >= m_MaxDelay)
        {
            if (m_Player1)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    m_Attack = true;
                    m_Sword.enabled = true;
                    m_Delay = 0;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    m_Attack = true;
                    m_Sword.enabled = true;
                    m_Delay = 0;
                }
            }
        }
        else
        {
            m_Delay += m_DelaySpeed * Time.deltaTime;
        }

        if (m_Attack)
        {
            if (m_Player1)
            {
                if (transform.localPosition.x <= 1)
                {
                    transform.position += m_AttackSpeed * Time.deltaTime;
                }
                else
                {
                    m_Attack = false;
                }
            }

            else
            {
                if (transform.localPosition.x >= -1)
                {
                    transform.position -= m_AttackSpeed * Time.deltaTime;
                }
                else
                {
                    m_Attack = false;
                }
            }
        }
        else
        {
            m_Sword.enabled = false;

            if (m_Player1)
            {
                if (transform.localPosition.x >= 0.3)
                {
                    transform.position -= m_AttackSpeed * Time.deltaTime;
                }
            }

            else
            {
                if (transform.localPosition.x <= -0.3)
                {
                    transform.position += m_AttackSpeed * Time.deltaTime;
                }
            }
        }

    }
}
