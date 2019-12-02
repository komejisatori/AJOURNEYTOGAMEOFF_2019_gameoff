using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Text m_MovingTest;

    public int m_basicpos;
    public int m_upinstance;
    public terrian[] m_terrainlist;
    public avatar_move m_avatar;
    private string m_texts;
    private char[] m_charlist;
    private int m_curpos = 0;
    
    void Start()
    {

        m_texts = m_MovingTest.text;
        m_MovingTest.text = " ";
        m_charlist = m_texts.ToCharArray();
        m_MovingTest.rectTransform.offsetMax = new Vector2(m_MovingTest.rectTransform.offsetMax.x, -m_basicpos);
    }

    // Update is called once per frame
    void Update()
    {

        // m_MovingTest
    }

    public IEnumerator GetAText()
    {
        m_MovingTest.text = m_MovingTest.text.Substring(0, m_MovingTest.text.Length-1) + m_charlist[m_curpos] + " ";
        if (m_curpos + 1 == m_texts.Length)
        {
            // avatar.starttomove
            m_avatar.m_create = true;
            m_avatar.transform.position = new Vector3(m_avatar.transform.position.x, m_avatar.transform.position.y, -20);
            m_MovingTest.text = " ";
            foreach (terrian terr in m_terrainlist)
            {
                terr.gameObject.transform.position = new Vector3 (terr.gameObject.transform.position.x, terr.gameObject.transform.position.y, -20);
            }

        }
        else if (m_charlist[m_curpos + 1] == '\n')
        {

            yield return new WaitForSeconds(0.2f);
            m_MovingTest.rectTransform.offsetMax = new Vector2(m_MovingTest.rectTransform.offsetMax.x, 
                m_MovingTest.rectTransform.offsetMax.y + m_upinstance);
            m_curpos += 1;
            StartCoroutine(GetAText());

        }
        else if (m_charlist[m_curpos + 1] != '\n')
        {
            yield return new WaitForSeconds(0.05f);
            m_curpos += 1;
            StartCoroutine(GetAText());
        }
    }

    public void StarttoShow()
    {
        StartCoroutine(GetAText());
    }
}
