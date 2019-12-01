using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_relative_y;
    public bool m_active;
    void Start()
    {
        m_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_active)
        {
            if (collision.collider.GetComponent<avatar_move>())
            {
                m_relative_y = this.gameObject.transform.position.y - collision.collider.GetComponent<avatar_move>().transform.position.y;
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (m_active)
        {
            if (collision.collider.GetComponent<avatar_move>())
            {
                avatar_move temp = collision.collider.GetComponent<avatar_move>();
                temp.gameObject.transform.position = new Vector3(temp.gameObject.transform.position.x, this.gameObject.transform.position.y - m_relative_y, temp.gameObject.transform.position.z);
            }
        }
    }
}
