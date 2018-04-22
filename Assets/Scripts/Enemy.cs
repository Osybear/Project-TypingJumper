using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D m_EnemyRB;
    public bool m_MoveLeft = false;
    public bool m_MoveRight = false;

    private void Start()
    {
        m_MoveLeft = true;    
    }

    private void Update()
    {
        if (m_MoveLeft == true)
        {
            m_EnemyRB.velocity = new Vector2(-2, m_EnemyRB.velocity.y);
        }

        if (m_MoveRight == true)
        {
            m_EnemyRB.velocity = new Vector2(2, m_EnemyRB.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.position.x > collision.transform.position.x)
        {
            if (Vector3.Distance(collision.transform.position, transform.position) < 3)
            {
                m_MoveRight = true;
                m_MoveLeft = false;
            }
        }

        if(transform.position.x < collision.transform.position.x)
        {
            if (Vector3.Distance(collision.transform.position, transform.position) < 3)
            {
                m_MoveLeft = true;
                m_MoveRight = false;
            }
        }

        if(collision.transform.name == "Player")
        {
            if(collision.transform.position.y > transform.position.y && (collision.transform.position.y - transform.position.y) > .5)
            {
                Destroy(gameObject);
            }
            else
            {
                Transform cam = collision.transform.GetChild(0).gameObject.transform;
                cam.GetComponent<Animator>().enabled = false;
                cam.SetParent(null, true);
                collision.transform.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
