using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        float width = this.GetComponent<BoxCollider2D>().bounds.extents.x;
        float height = this.GetComponent<BoxCollider2D>().bounds.extents.y;
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y),
            new Vector2(width * 2, height * 2), 0);
        if (!m_initactivate)
        {
            foreach (Transform tran in GetComponentsInChildren<Transform>())
                tran.gameObject.layer = LayerMask.NameToLayer("not_activate_layer");
            foreach(Collider2D hit in hitColliders)
                if (hit.GetComponent<enemy>())
                    hit.GetComponent<enemy>().gameObject.layer = LayerMask.NameToLayer("not_activate_layer");
            /*
            foreach (BoxCollider2D collider in m_colliders)
            {
                if (!collider.isTrigger)
                    collider.enabled = false;
            }
            */
        }
        else
        {
            foreach (Transform tran in GetComponentsInChildren<Transform>())
                tran.gameObject.layer = LayerMask.NameToLayer("activate_layer");
            foreach (Collider2D hit in hitColliders)
                if (hit.GetComponent<enemy>())
                    hit.GetComponent<enemy>().gameObject.layer = LayerMask.NameToLayer("avatar");
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
        {
            foreach (Transform tran in GetComponentsInChildren<Transform>())
                tran.gameObject.layer = LayerMask.NameToLayer("activate_layer");
            float width = this.GetComponent<BoxCollider2D>().bounds.extents.x;
            float height = this.GetComponent<BoxCollider2D>().bounds.extents.y;
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y),
                new Vector2(width * 2, height * 2), 0);
            foreach (Collider2D hit in hitColliders)
            {
                if (hit.GetComponent<enemy>())
                {
                    hit.GetComponent<enemy>().gameObject.layer = LayerMask.NameToLayer("avatar");

                }
                if (hit.GetComponent<terrian>())
                {
                    hit.GetComponent<terrian>().GiveGravity();
                    hit.GetComponent<terrian>().gameObject.layer = LayerMask.NameToLayer("avatar");
                }
            }
        }
        /*
        foreach (BoxCollider2D collider in m_colliders)
        {
            if (!collider.isTrigger)
                collider.enabled = true;
        }
        */
        else
        {
            foreach (Transform tran in GetComponentsInChildren<Transform>())
                tran.gameObject.layer = LayerMask.NameToLayer("not_activate_layer");
            float width = this.GetComponent<BoxCollider2D>().bounds.extents.x;
            float height = this.GetComponent<BoxCollider2D>().bounds.extents.y;
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y),
                new Vector2(width*2, height*2), 0);
            foreach (Collider2D hit in hitColliders)
                if (hit.GetComponent<enemy>())
                {
                    
                    hit.GetComponent<enemy>().gameObject.layer = LayerMask.NameToLayer("not_activate_layer");
                }

        }
        /*
        foreach (BoxCollider2D collider in m_colliders)
        {
            if (!collider.isTrigger)
                collider.enabled = false;
        }
        */
    }

    public int CheckIn()
    {
        // it must in
        return 0;
    }

    public void SetZIndex()
    {
        windows_frame[] sons = this.GetComponentsInChildren<windows_frame>();
        Canvas[] cans = this.GetComponentsInChildren<Canvas>();
        windows_body body = this.GetComponentInChildren<windows_body>();
        foreach (windows_frame son in sons)
        { 
            son.transform.position = new Vector3(son.transform.position.x, son.transform.position.y, m_z_index * 10);
        }
        foreach (Canvas can in cans)
        {
            can.transform.position = new Vector3(can.transform.position.x, can.transform.position.y, m_z_index * 10 + 0.2f);
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
