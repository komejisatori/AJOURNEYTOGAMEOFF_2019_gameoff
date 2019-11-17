using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window1_startgame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool m_gamestarted = false;
    public text_movement m_text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            if (!m_gamestarted)
            {
                m_gamestarted = true;
                m_text.StarttoShow();
            }
    }
}
