using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class window_stack
{
    // Start is called before the first frame update
    private List<window_select> m_windows_stack ;
    private static window_stack instance;
    private int m_len = 0;
    private window_stack()
    {
        window_select[] windows = UnityEngine.Object.FindObjectsOfType<window_select>();
        m_len = windows.Length;
        Debug.Log(windows.Length);
        m_windows_stack = new List<window_select>(windows);
        m_windows_stack.Sort(new window_select());
    }
    public static window_stack GetInstance()
    {
        if (instance == null)
        {
            instance = new window_stack();
        }
        return instance;
    }

    public static void Reload()
    {
        instance = null;
    }

    public void PopWindow(int z_index)
    {
        window_select w_temp = m_windows_stack[z_index];
        for (int i = z_index; i > 0; i--)
        {
            m_windows_stack[i] = m_windows_stack[i-1];
            m_windows_stack[i].m_z_index = i;
            m_windows_stack[i].SetZIndex();
        }
        m_windows_stack[0] = w_temp;
        m_windows_stack[0].m_z_index = 0;
        m_windows_stack[0].SetZIndex();
    }

    public void DownWindow(int z_index)
    {
        window_select w_temp = m_windows_stack[z_index];
        for (int i = z_index; i < m_len-1; i++)
        {
            m_windows_stack[i] = m_windows_stack[i + 1];
            m_windows_stack[i].m_z_index = i;
            m_windows_stack[i].SetZIndex();
        }
        m_windows_stack[m_len - 1] = w_temp;
        m_windows_stack[m_len - 1].m_z_index = m_len - 1;
        m_windows_stack[m_len - 1].SetZIndex();
    }

    public void SetWindowCollider(int z_index)
    {
        
        for(int i = m_len-1; i >= 0; i--)
        {
            if (i > z_index)
                m_windows_stack[i].SetActivate(false);
            if (i <= z_index)
                m_windows_stack[i].SetActivate(true);   
        }
        
    }
}

