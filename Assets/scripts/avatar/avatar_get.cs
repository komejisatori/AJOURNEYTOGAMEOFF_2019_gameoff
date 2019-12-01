using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avatar_get : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] m_monos = { false, false, false, false };
    public bool[] m_gets = { false, false, false, false };
    public bool m_canpush = false;
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Sprite sp1;
    public Sprite sp2;
    public Sprite sp3;
    public Sprite sp4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Getmono(int number)
    {
        m_gets[number] = true;
        if (number == 0)
        {
            img1.sprite = sp1;
        }
        if (number == 1)
        {
            img2.sprite = sp2;
        }
        if (number == 2)
        {
            img3.sprite = sp3;
        }
        if (number == 3)
        {
            img4.sprite = sp4;
        }
    }

    public int CalList()
    {
        if(m_monos[1] == false) // photo
        {
            return 1;
        }
        if(m_monos[1] == true && m_monos[3] == false) // name
        {
            return 2;
        }
        if (m_monos[1] == true && m_monos[3] == true && m_monos[2] == false) // func
        {
            return 3;
        }
        if (m_monos[1] == true && m_monos[3] == true && m_monos[2] == true && m_monos[0] == false) // push
        {
            return 4;
        }
        return 5;
    }

}
