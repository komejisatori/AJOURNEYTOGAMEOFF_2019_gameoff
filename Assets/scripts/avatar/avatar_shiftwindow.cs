using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_shiftwindow : MonoBehaviour
{
    // Start is called before the first frame update
    public window_select cur_window;
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
                    if (window.GetComponent<chatbox_control>())
                    {
                        window.GetComponent<chatbox_control>().GiveList(this.GetComponent<avatar_get>().CalList() > 4 ? 3: this.GetComponent<avatar_get>().CalList() - 1);
                    }
                    if (window.GetComponent<window_enemy>())
                    {
                        if (this.GetComponent<avatar_get>().m_gets[2] == true)
                        {
                            window.GetComponent<window_enemy>().delete_block();
                        }
                    }
                    if (window.GetComponent<gitpush>())
                    {
                        if (window.GetComponent<gitpush>().m_appear)
                            StartCoroutine(window.GetComponent<gitpush>().ControlMove());
                        else if(window.GetComponent<gitpush>().m_rappear)
                            StartCoroutine(window.GetComponent<gitpush>().ControlRMove());
                    }
                    if (window.GetComponent<windows1>())
                    {
                        if (this.GetComponent<avatar_get>().m_canpush)
                        {
                            window_stack.Reload();
                            Application.LoadLevel("Main");
                        }
                        if (this.GetComponent<avatar_get>().m_gets[3] == false)
                        {
                            avatar_move am = this.GetComponent<avatar_move>();
                            am.transform.position = new Vector3(am.m_x, am.m_pos1, am.transform.position.z);
                            am.m_start_control = false;
                        }
                    }
                    if (cur_window.GetComponent<gitpush>())
                    {
                        stack.DownWindow(cur_window.m_z_index);
                        cur_window.GetComponent<gitpush>().Hidden();
                    }
                    if (cur_window.GetComponent<chatbox_control>())
                    {
                        cur_window.GetComponent<chatbox_control>().StopAll();
                    }
                    cur_window = window;
                    break;
                }
            }
        }
    }
}
