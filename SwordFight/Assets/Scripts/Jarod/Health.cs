using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField]
    private float m_Health;

    private float m_MaxHealth;

    [SerializeField]
    private Slider m_PlayerHP;

    [SerializeField]
    private Image m_SwordHP;

    private bool m_Blocking;

    [SerializeField]
    private Sprite m_3HP, m_2HP, m_1HP, m_0HP;

    [SerializeField]
    private Animator m_Player;

    [SerializeField]
    private Rigidbody m_Rigidbody;

    [SerializeField]
    private Vector2 m_Knockback;

    [SerializeField]
    private Moving m_PlayerMove;

    [SerializeField]
    private SpriteRenderer m_PlayerSprite;

    [SerializeField]
    private float m_Delay, m_DelaySpeed;

    private float m_MaxDelay;

    // Use this for initialization
    void Start ()
    {
        m_MaxHealth = m_Health;
        m_MaxDelay = m_Delay;
    }

    public void Blocking(bool blocking)
    {
        m_Blocking = blocking;
    }

    public void TakingDamage()
    {
        if (!m_Blocking)
        {
            m_Health--;
            m_Rigidbody.AddForce(m_Knockback, ForceMode.Impulse);
            m_PlayerMove.Hit();
            m_PlayerSprite.color = Color.red;
            m_Delay = 0;
        }

        else
        {
            m_Rigidbody.AddForce(m_Knockback / 2, ForceMode.Impulse);
            m_PlayerMove.Hit();
            m_PlayerSprite.color = Color.cyan;
            m_Delay = 0;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_PlayerHP.maxValue = m_MaxHealth;
        m_PlayerHP.value = m_Health;

        m_Rigidbody.AddForce(0, -10, 0);

        if (m_Health <= 0)
        {
            transform.gameObject.active = false;
        }

        if (m_Health >= 3)
        {
            m_SwordHP.sprite = m_3HP;
        }
        else if (m_Health >= 2)
        {
            m_SwordHP.sprite = m_2HP;
        }
        else if (m_Health >= 1)
        {
            m_SwordHP.sprite = m_1HP;
        }
        else
        {
            m_Player.SetTrigger("Dead");
            m_SwordHP.sprite = m_0HP;
        }

        if (m_Delay >= m_MaxDelay)
        {
            m_PlayerSprite.color = Color.white;
        }

        else
        {
            m_Delay += m_DelaySpeed * Time.deltaTime;
        }
    }
}
