using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_jump : MonoBehaviour
{
    // Controlling Avatar Jump Collider
    // Start is called before the first frame update
    private BoxCollider2D m_collider;
    private Rigidbody2D m_rig;
    void Start()
    {
        m_collider = this.GetComponent<BoxCollider2D>();
        m_rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rig.velocity.y > 0)
        {
            m_collider.enabled = false;
        }
        else
        {
            m_collider.enabled = true;
        }
    }
}
