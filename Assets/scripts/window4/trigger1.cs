using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger1 : MonoBehaviour
{
    public gitpush pushwindow;
    public bool m_opened = false;
    public board m_board;
    // Start is called before the first frame update
    void Start()
    {
        m_opened = false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<avatar_move>())
        {
            if (!collision.GetComponent<avatar_get>().m_canpush)
            {
                m_board.GetOut();
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<avatar_move>())
        {
            //Debug.Log("entered");
            if (!collision.GetComponent<avatar_get>().m_canpush)
            {
                m_board.GetIn();
                m_board.Show(0);
            }
            if (!m_opened)
            {
                if (!collision.GetComponent<avatar_get>().m_canpush)
                    pushwindow.StartMove();
                else
                {
                    pushwindow.StartMoveBack();
                }
            }
        }
    }

}
