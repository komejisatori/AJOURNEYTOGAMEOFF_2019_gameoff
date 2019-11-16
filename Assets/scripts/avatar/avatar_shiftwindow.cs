using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_shiftwindow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per fram0.1
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(0.1f, 0.1f), 0);
            foreach (Collider2D hitc in hitColliders)
            {
                window_select window = hitc.GetComponentInParent<window_select>();
                if (window && window.m_z_index != 0)
                {
                    window_stack stack = window_stack.GetInstance();
                    stack.PopWindow(window.m_z_index);
                    stack.SetWindowCollider(0);
                    break;
                }
            }
        }
    }
}
