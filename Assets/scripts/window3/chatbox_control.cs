using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatbox_control : MonoBehaviour
{
    // Start is called before the first frame update
    private int m_listindex;
    public List<chatbox> m_list1;
    public List<chatbox> m_list2;
    public List<chatbox> m_list3;
    public List<chatbox> m_list4;
    public float m_chatstart_x1;
    public float m_chatstart_x2;

    public int[] m_length;
    private List<List<chatbox>> m_listList;
    private int m_listlength = 4;
    private int m_len;
    private bool m_switch = false;
    public block m_block;
    void Start()
    {
        m_listList = new List<List<chatbox>>(m_listlength);
        m_listList.Add(m_list1);
        m_listList.Add(m_list2);
        m_listList.Add(m_list3);
        m_listList.Add(m_list4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveList(int index)
    {
        m_switch = true;
        m_listindex = 0;
        m_len = m_length[index];
        for(int i=0; i< m_listlength; i++)
        {
            if (i != index)
            {
                HideList(m_listList[i]);
            }
            else
            {
                HideList(m_listList[i]);
                ShowList(m_listList[i], m_chatstart_x1, m_chatstart_x2);
                if (i == 3)
                {
                    m_block.gameObject.SetActive(false);
                }
            }
        }
        
    }

    public void ShowList(List<chatbox> list, float m_chatstart_x1, float m_chatstart_x2)
    {
        if (m_switch)
            StartCoroutine(PopList(list, m_chatstart_x1, m_chatstart_x2));
    }

    public IEnumerator Endlist(List<chatbox> list)
    {
        yield return new WaitForSeconds(1f);
        for (int i = m_listindex - 1; i >= 0; i--)
        {
            list[i].Stop();
        }
    }

    public IEnumerator PopList(List<chatbox> list, float m_chatstart_x1, float m_chatstart_x2)
    {
        if (m_switch)
        {
            list[m_listindex].Appear(m_chatstart_x1, m_chatstart_x2);
            list[m_listindex].Adjust();
            m_listindex += 1;
            
            if (m_listindex < m_len)
            {
                yield return new WaitForSeconds(1.6f);
                StartCoroutine(PopList(list, m_chatstart_x1, m_chatstart_x2));
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(Endlist(list));
            }
        }
    }

    public void StopAll()
    {
        m_switch = false;
        for (int i = 0; i < m_listlength; i++)
        {
            HideList(m_listList[i]);                
        }
    }

    public void HideList(List<chatbox> list)
    {
        foreach(chatbox l in list)
        {
            l.Hide();
        }
    }

}
