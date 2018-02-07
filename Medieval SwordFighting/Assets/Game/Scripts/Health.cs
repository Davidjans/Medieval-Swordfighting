using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private float m_Health;

    private float m_MaxHealth;

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
		if (m_Health <= 0)
        {
            Destroy(transform.gameObject);
        }
	}
}
