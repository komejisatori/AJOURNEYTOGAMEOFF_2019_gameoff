using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono3 : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_start_pos_x;
    private float m_start_pos_y;
    void Start()
    {
        m_start_pos_x = this.gameObject.transform.position.x;
        m_start_pos_y = this.gameObject.transform.position.y;
        this.gameObject.transform.position = new Vector3(10000, 10000, this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Appear()
    {
        this.gameObject.transform.position = new Vector3(m_start_pos_x, m_start_pos_y, this.gameObject.transform.position.z);
    }
}
