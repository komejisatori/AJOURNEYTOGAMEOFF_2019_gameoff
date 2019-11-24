using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatbox : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_startpos_y;
    public int m_speed_y;
    public int m_z_index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Adjust()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + m_speed_y, m_z_index);
    }

    public void Appear()
    {
        this.transform.position = new Vector3(this.transform.position.x, m_startpos_y, m_z_index);
    }

    public void Hide()
    {
        this.transform.position = new Vector3(this.transform.position.x, m_startpos_y, 100);
    }
}
