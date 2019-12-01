using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatbox : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_startpos_y;
    private float m_speed_y = 0.01f;
    public float m_z_index;
    public bool m_isreverse;
    private bool m_can_move = false;
    void Start()
    {
        Hide();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_can_move)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + m_speed_y, m_z_index);
            if (this.transform.localPosition.y > 2.5)
            {
                Hide();
            }
        }

    }

    public void Adjust()
    {
        //Debug.Log("start adjust");
        this.GetComponentInChildren<elevator>().m_active = true;
        m_can_move = true;
        //this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + m_speed_y, m_z_index);
    }

    public void Stop()
    {
        this.GetComponentInChildren<elevator>().m_active = false;
        m_can_move = false;
    }

    public void Appear(float m_chatstart_x1, float m_chatstart_x2)
    {
        if (m_isreverse)
            this.transform.localPosition = new Vector3(m_chatstart_x2, m_startpos_y, m_z_index);
        else
            this.transform.localPosition = new Vector3(m_chatstart_x1, m_startpos_y, m_z_index);
        this.GetComponentInChildren<BoxCollider2D>().enabled = true;
        //this.GetComponent<Canvas>().transform.localPosition= new Vector3(m_chatstart_x1, m_startpos_y, 0);
    }

    public void Hide()
    {
        Stop();
        this.transform.localPosition = new Vector3(10000, 10000, 100);
        this.GetComponentInChildren<BoxCollider2D>().enabled = false;
        //Vector3 rp = this.GetComponentInChildren<Text>().rectTransform.position;
        //rp = new Vector3(rp.x, rp.y, 100);
        //this.GetComponent<RectTra nsform>().anchoredPosition= new Vector3(this.transform.position.x, this.transform.position.y, -30);
    }
}
