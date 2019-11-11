using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_select : MonoBehaviour, IComparer<window_select>
{
    // Start is called before the first frame update
    public bool m_activate;
    public int m_z_index; // windows init order
    private BoxCollider2D[] m_colliders;
    
    void Start()
    {
        this.SetZIndex();
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
        if (!m_activate)
        {
            m_activate = true;
            foreach (BoxCollider2D collider in m_colliders)
            {
                if (!collider.isTrigger)
                    collider.enabled = true;
            }
        }
        window_stack stack = window_stack.GetInstance();
        stack.PopWindow(m_z_index);
    }

    public void SetZIndex()
    {
        windows_frame[] sons = this.GetComponentsInChildren<windows_frame>();
        windows_body body = this.GetComponentInChildren<windows_body>();
        foreach (windows_frame son in sons)
        { 
            son.transform.position = new Vector3(son.transform.position.x, son.transform.position.y, m_z_index * 10);
        }
        body.transform.position = new Vector3(body.transform.position.x, body.transform.position.y, m_z_index * 10 + 1);
    }

    public int Compare(window_select a, window_select b)
    {
        if (a.m_z_index > b.m_z_index)
        {
            return 1;
        }
        else if (a.m_z_index < b.m_z_index)
        {
            return -1;//小的放右边
        }
        else
        {
            return 0;//不变
        }
    }
}
