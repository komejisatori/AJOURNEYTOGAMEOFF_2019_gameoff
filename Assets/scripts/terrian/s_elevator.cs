using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_elevator : MonoBehaviour
{
    // Start is called before the first frame update
    private float m_relative_x;
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
                m_relative_x = this.gameObject.transform.position.x - collision.collider.GetComponent<avatar_move>().transform.position.x;
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
                temp.gameObject.transform.position = new Vector3(temp.gameObject.transform.position.x - m_relative_x, this.gameObject.transform.position.y , temp.gameObject.transform.position.z);
            }
        }
    }
}
