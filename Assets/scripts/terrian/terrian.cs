using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrian : MonoBehaviour
{
    // Start is called before the first frame update
    public bool m_sleep = true;
    private Rigidbody2D m_rig;
    public bool m_start_hide;
    private float m_originindex;
    public bool m_cangive = false;
    void Start()
    {
        m_originindex = this.transform.position.z;
        if (m_start_hide)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 10);
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        m_rig = this.GetComponent<Rigidbody2D>();
        m_rig.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_sleep)
        {
            m_rig.Sleep();
            
        }
    }

    public void Comeout()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, m_originindex);
        this.GetComponent<BoxCollider2D>().enabled = true;

    }

    public void GiveGravity()
    {
        if (m_cangive)
        {
            m_sleep = false;
            m_rig.constraints = RigidbodyConstraints2D.None;
        }
    }
}
