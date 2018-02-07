using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    [SerializeField]
    private Vector3 m_Speed, m_ShieldSpeed;

    [SerializeField]
    private bool m_Player1, m_Right;

    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private Transform m_OtherPlayer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (m_Player1)
        {
            //Blocking
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= m_ShieldSpeed * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += m_ShieldSpeed * Time.deltaTime;
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= m_Speed * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += m_Speed * Time.deltaTime;
                }
            }
        }

        else if (!m_Player1)
        {
            //Blocking
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position -= m_ShieldSpeed * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += m_ShieldSpeed * Time.deltaTime;
                }
            }

            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position -= m_Speed * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += m_Speed * Time.deltaTime;
                }
            }
        }

        if (m_Right)
        {
            m_SpriteRenderer.flipX = false;
        }

        else
        {
            m_SpriteRenderer.flipX = true;
        }
        
        if (transform.position.x >= m_OtherPlayer.position.x)
        {
            m_Right = false;
        }

        else
        {
            m_Right = true;
        }
    }
}
