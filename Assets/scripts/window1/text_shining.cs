using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_shining : MonoBehaviour
{
    public Text m_text;
    private string[] m_texts = {"/_", "-_","\\_","-_" };
    private int cur_pos = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetNewText());
    }

    IEnumerator SetNewText()
    {
        cur_pos += 1;
        if (cur_pos >= 4)
        {
            cur_pos = 0;
        }
        m_text.text = m_texts[cur_pos];
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SetNewText());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
