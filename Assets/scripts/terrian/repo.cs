using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repo : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_start_pos_x;
    public float m_start_pos_y;
    void Start()
    {
        m_start_pos_x = this.gameObject.transform.position.x;
        m_start_pos_y = this.gameObject.transform.position.y;
        this.gameObject.transform.position = new Vector3(10000, 10000, this.gameObject.transform.position.z);
    }

    public void Getback()
    {
        this.gameObject.transform.position = new Vector3(m_start_pos_x, m_start_pos_y, this.gameObject.transform.position.z);
        if (this.GetComponentInChildren<monogetter>())
        {
            monogetter gt = this.GetComponentInChildren<monogetter>();
            gt.gameObject.transform.position = new Vector3(gt.gameObject.transform.position.x, gt.gameObject.transform.position.y, this.gameObject.transform.position.z - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
