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

	// Use this for initialization
	void Start ()
    {
        m_MaxHealth = m_Health;

    }

    public void TakingDamage()
    {
        m_Health--;
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_PlayerHP.maxValue = m_MaxHealth;
        m_PlayerHP.value = m_Health;


        if (m_Health <= 0)
        {
            Destroy(transform.gameObject);
        }
	}
}
