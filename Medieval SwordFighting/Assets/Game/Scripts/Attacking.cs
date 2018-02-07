using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour {

    [SerializeField]
    private BoxCollider m_Sword;

    private bool m_Attack;

    [SerializeField]
    private Vector3 m_AttackSpeed;

    [SerializeField]
    private float m_Delay, m_DelaySpeed;

    private float m_MaxDelay;

	// Use this for initialization
	void Start ()
    {
        m_MaxDelay = m_Delay;
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update () {

        if (m_Delay >= m_MaxDelay)
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
            m_Delay += m_DelaySpeed * Time.deltaTime;
        }

        if (m_Attack)
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
            m_Sword.enabled = false;
            if (transform.localPosition.x >= 0.3)
            {
                transform.position -= m_AttackSpeed * Time.deltaTime;
            }
        }

    }
}
