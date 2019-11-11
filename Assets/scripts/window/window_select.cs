using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_select : MonoBehaviour
{
    // Start is called before the first frame update
    public bool m_activate;
    private BoxCollider2D[] m_colliders;
    void Start()
    {
        m_colliders = this.GetComponentsInChildren<BoxCollider2D>();
        if (!m_activate)
        {
            foreach (BoxCollider2D collider in  m_colliders)
            {
                if (!collider.isTrigger)
                    collider.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("click");
        if (!m_activate)
        {
            Debug.Log("click");
            m_activate = true;
            foreach (BoxCollider2D collider in m_colliders)
            {
                if (!collider.isTrigger)
                    collider.enabled = true;
            }
        }
    }
}
