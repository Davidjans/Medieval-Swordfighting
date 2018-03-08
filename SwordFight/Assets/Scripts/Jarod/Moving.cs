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

    [SerializeField]
    private GameObject m_PlayerShield;

    private bool m_Move = true;

    [SerializeField]
    private Animator m_PlayerAnim;

    // Use this for initialization
    void Start()
    {

    }

    public void Hit()
    {
        m_Move = false;
    }

    public void Attacking(bool attacking)
    {
        m_Move = !attacking;
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_Move = true;
    }

    // Update is called once per frame
    void Update()
    {
        m_PlayerAnim.SetBool("Walking", false);
        m_PlayerAnim.SetBool("Walking2", false);

        if (m_Move)
        {
            if (m_Player1)
            {
                //Blocking
                if (m_PlayerShield.active)
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
                        m_PlayerAnim.SetBool("Walking", true);
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.position += m_Speed * Time.deltaTime;
                        m_PlayerAnim.SetBool("Walking", true);
                    }
                }
            }

            else if (!m_Player1)
            {
                //Blocking
                if (m_PlayerShield.active)
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
                        m_PlayerAnim.SetBool("Walking2", true);
                    }

                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        transform.position += m_Speed * Time.deltaTime;
                        m_PlayerAnim.SetBool("Walking2", true);
                    }
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
        
        //if (transform.position.x >= m_OtherPlayer.position.x)
        //{
        //    m_Right = false;
        //}
        
        //else
        //{
        //    m_Right = true;
        //}
    }
}
