using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monogetter : MonoBehaviour
{
    public int m_wanttype;
    public Sprite m_successImage;
    public SpriteRenderer m_spr;
    public Sprite m_sprsucc;
    public repo repo1;
    public repo repo2;
    public repo repo3;
    public repo repo4;
    public board m_board;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<avatar_get>())
        {
            if (collision.GetComponent<avatar_get>().m_gets[m_wanttype])
            {
                if (m_wanttype == 0)
                {
                    if (collision.GetComponent<avatar_get>().CalList() < 4)
                        m_board.GetOut();
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<avatar_get>())
        {
            if (collision.GetComponent<avatar_get>().m_gets[m_wanttype])
            {
                this.GetComponentInChildren<SpriteRenderer>().sprite = m_successImage;
                collision.GetComponent<avatar_get>().m_monos[m_wanttype] = true;
                if(m_wanttype == 1)
                {
                    repo1.Getback();
                    repo2.Getback();
                    repo3.Getback();
                    repo4.Getback();
                }
                if(m_wanttype == 2)
                {
                    collision.GetComponent<avatar_health>().m_attack = true;
                }
                if(m_wanttype == 3)
                {
                    m_spr.sprite = m_sprsucc;
                }
                if(m_wanttype == 0)
                {
                    if (collision.GetComponent<avatar_get>().CalList() == 5)
                    {
                        m_board.Show(3);
                        m_board.GetIn();
                        collision.GetComponent<avatar_get>().m_canpush = true;
                    }
                    if (collision.GetComponent<avatar_get>().CalList() <= 4)
                    {
                        m_board.Show(2);
                        m_board.GetIn();
                    }
                }
            }
        }
    }

}
