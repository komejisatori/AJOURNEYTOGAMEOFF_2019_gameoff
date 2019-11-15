using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_select : MonoBehaviour, IComparer<window_select>
{
    // Start is called before the first frame update
    public bool m_initactivate;
    public int m_z_index; // windows init order
    public BoxCollider2D m_trigger;
    private BoxCollider2D[] m_colliders;
    
    void Start()
    {
        this.SetZIndex();
        m_colliders = this.GetComponentsInChildren<BoxCollider2D>();
        
        if (!m_initactivate)
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
        /*
        window_stack stack = window_stack.GetInstance();
        int avatar_index = CheckIn();
        stack.PopWindow(m_z_index);
        stack.SetWindowCollider(avatar_index);    
        */
    }

    public void SetActivate(bool activate)
    {
        if (activate)
            foreach (BoxCollider2D collider in m_colliders)
            {
                if (!collider.isTrigger)
                    collider.enabled = true;
            }
        else
            foreach (BoxCollider2D collider in m_colliders)
            {
                if (!collider.isTrigger)
                    collider.enabled = false;
            }
    }

    public int CheckIn()
    {
        avatar_move avatar = FindObjectOfType<avatar_move>();
        if (Intersect(avatar.GetComponent<BoxCollider2D>()))
            avatar.m_z_index = 0;
        else
            if (avatar.m_z_index < m_z_index)
                avatar.m_z_index += 1;
        return avatar.m_z_index;
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

    private bool Intersect(BoxCollider2D avatar_collider)
    {
        Vector3 avatar_center = avatar_collider.bounds.center;
        Vector3 box_center = this.m_trigger.bounds.center;
        float box_extent_x = this.m_trigger.bounds.extents.x;
        float box_extent_y = this.m_trigger.bounds.extents.y;
        if (avatar_center.x < (box_center.x + box_extent_x) && avatar_center.x > (box_center.x - box_extent_x))
            if (avatar_center.y < (box_center.y + box_extent_y) && avatar_center.y > (box_center.y - box_extent_y))
                return true;
        return false;
    }
}
