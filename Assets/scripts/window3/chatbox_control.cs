using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatbox_control : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_listindex;
    public List<chatbox> m_list1;
    public List<chatbox> m_list2;
    public List<chatbox> m_list3;
    public int[] m_length;
    private List<List<chatbox>> m_listList;
    private int m_listlength = 3;
    private int m_len;
    void Start()
    {
        m_listList = new List<List<chatbox>>(m_listlength);
        m_listList.Add(m_list1);
        m_listList.Add(m_list2);
        m_listList.Add(m_list3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveList(int index)
    {
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
                ShowList(m_listList[i]);
            }
        }
        
    }

    public void ShowList(List<chatbox> list)
    {
        StartCoroutine(PopList(list));
    }

    public IEnumerator PopList(List<chatbox> list)
    {
        
        for(int i = m_listindex - 1;i > 0;i--)
        {
            list[i].Adjust();
        }
        list[m_listindex].Appear();
        m_listindex += 1;
        yield return new WaitForSeconds(1f);
        if (m_listindex < m_len)
        {
            StartCoroutine(PopList(list));
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
