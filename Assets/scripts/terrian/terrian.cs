using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrian : MonoBehaviour
{
    // Start is called before the first frame update
    public bool m_sleep = true;
    private Rigidbody2D m_rig;
    void Start()
    {
        m_rig = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_sleep)
            m_rig.Sleep();
    }

    public void GiveGravity()
    {
        m_sleep = false;
    }
}
