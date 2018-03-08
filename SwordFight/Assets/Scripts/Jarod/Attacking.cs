using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacking : MonoBehaviour
{

    [SerializeField]
    private BoxCollider m_Sword;

    private bool m_Attack, m_Hit;

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

    [SerializeField]
    private GameObject m_OtherPlayer;

    [SerializeField]
    private Attacking m_OtherAttack;

    [SerializeField]
    private Rigidbody m_Rigidbody;

    [SerializeField]
    private Vector2 m_Knockback;

    [SerializeField]
    private Moving m_PlayerMove;

    [SerializeField]
    private Animator m_PlayerAnim;

    // Use this for initialization
    void Start()
    {
        m_MaxDelay = m_Delay;
    }

    public bool SwordHit()
    {
        return (m_Attack);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_OtherPlayer)
        {
            if (m_Hit)
            {
                if (m_OtherAttack.SwordHit())
                {
                    m_Rigidbody.AddForce(m_Knockback, ForceMode.Impulse);
                    m_PlayerMove.Hit();
                    m_Hit = false;
                }
                else
                {
                    m_OtherHealth.TakingDamage();
                    m_Hit = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_AttackBar.maxValue = m_MaxDelay;
        m_AttackBar.value = m_Delay;

        if (m_Delay >= m_MaxDelay)
        {
            if (m_Player1)
            {
                if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    m_Attack = true;
                    m_Hit = true;
                    m_Sword.enabled = true;
                    m_Delay = 0;
                    m_PlayerAnim.SetTrigger("Attack");
                    m_PlayerMove.Attacking(m_Attack);
                    m_Rigidbody.AddForce(new Vector3(1, 2, 0), ForceMode.Impulse);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
                {
                    m_Attack = true;
                    m_Hit = true;
                    m_Sword.enabled = true;
                    m_Delay = 0;
                    m_PlayerAnim.SetTrigger("Attack2");
                    m_PlayerMove.Attacking(m_Attack);
                    m_Rigidbody.AddForce(new Vector3(-1, 2, 0), ForceMode.Impulse);
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
                    m_Hit = false;
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
                    m_Hit = false;
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
