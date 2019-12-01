using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gitpush : MonoBehaviour
{
    // Start is called before the first frame update
    private bool m_moving = false;
    private bool m_rmoving = false;
    private bool m_movingreverse = false;
    public bool m_appear = false;
    public bool m_rappear = false;
    public float m_start_pos_x;
    public float m_start_pos_y;
    public float m_start_pos_z;
    public float m_speed;
    public trigger1 tr;
    void Start()
    {
        m_start_pos_x = this.gameObject.transform.position.x;
        m_start_pos_y = this.gameObject.transform.position.y; 
        m_start_pos_z = this.gameObject.transform.position.z;
        this.gameObject.transform.position = new Vector3(10000, 10000, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rmoving)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x-m_speed, this.gameObject.transform.position.y, 4);
        }
        else if (m_moving)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+m_speed, 4);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        /*
        if (other.GetComponent<avatar_move>())
        {
            Debug.Log("entered");
            if (!m_appear)
            {
                m_appear = true;
                this.transform.position = new Vector3(m_start_pos_x, m_start_pos_y, m_start_pos_z);
                StartCoroutine(StartMove());
            }
        }
        */
    }

    public void StartMove()
    {
        
        this.gameObject.transform.position = new Vector3(m_start_pos_x, m_start_pos_y, m_start_pos_z);
        m_appear = true;
        //StartCoroutine(ControlMove());
    
    }

    public void StartMoveBack()
    {
        this.gameObject.transform.position = new Vector3(m_start_pos_x, m_start_pos_y, m_start_pos_z);
        m_rappear = true;
    }

    public void Hidden()
    {
        m_appear = false;
        m_rappear = false;
        this.transform.position = new Vector3(10000, 10000, 4);
    }

    public IEnumerator ControlMove()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("moving");
        m_moving = true;
        yield return new WaitForSeconds(2.5f);
        Debug.Log("moving forward");
        m_moving = false;
        //Hidden();
        tr.m_opened = false;
        //yield return new WaitForSeconds(2f);
        //m_moving
    }

    public IEnumerator ControlRMove()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("moving");
        m_moving = true;
        m_rmoving = true;
        yield return new WaitForSeconds(0.8f);
        m_rmoving = false;
        yield return new WaitForSeconds(2.5f);
        Debug.Log("moving forward");
        m_moving = false;
        //Hidden();
        tr.m_opened = false;
    }

}
