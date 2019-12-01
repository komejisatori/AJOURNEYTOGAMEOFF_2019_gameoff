using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_move : MonoBehaviour
{
    private Rigidbody2D m_rig;
    private Transform m_camera;
    public mono3 m_mono3;
    public int m_speed_horizon;
    public int m_speed_verical; // jump force
    public float distanceY;
    public int m_z_index;
    public float smooth;
    public bool m_start_control;
    public terrian[] m_terrianlist;
    private int m_start_pos;
    public bool m_create;
    public float m_x;
    public float m_pos1;
    public float m_pos2;
    // Start is called before the first frame update
    void Start()
    {
        m_x = this.gameObject.transform.position.x;
        m_pos1 = m_terrianlist[0].gameObject.transform.position.y;
        m_pos2 = m_terrianlist[1].gameObject.transform.position.y;
        m_create = false;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -20);
        m_rig = this.GetComponent<Rigidbody2D>();
        m_rig.Sleep();
        m_rig.constraints = RigidbodyConstraints2D.FreezeAll;
        m_camera = Camera.main.transform;
        m_start_control = false;
    }

    static public void EnableMove()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_start_control)
        {
            float speed_temp = Input.GetAxis("Horizontal");
            speed_temp = speed_temp * m_speed_horizon;
            m_rig.velocity = new Vector2(speed_temp, m_rig.velocity.y);
            float cx = m_rig.position.x;
            float cy = m_camera.position.y;
            if (Input.GetKeyDown(KeyCode.J) )
            {
                m_rig.AddForce(new Vector2(0, m_speed_verical));
            }
            if (m_rig.velocity.y == 0)
            {
                cy = m_rig.position.y - distanceY;
            }

            //m_camera.position = Vector3.Lerp(m_camera.position,  new Vector3(cx, cy, m_camera.position.z), smooth * Time.deltaTime);
        }
        else
        {
            m_rig.Sleep();
            m_rig.constraints = RigidbodyConstraints2D.FreezeAll;
            if (m_create)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    this.transform.position = new Vector3(m_x, m_pos1, this.transform.position.z);
                    m_start_pos = 0;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    this.transform.position = new Vector3(m_x, m_pos2, this.transform.position.z);
                    m_start_pos = 1;
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    m_start_control = true;
                    m_rig.constraints = RigidbodyConstraints2D.FreezeRotation;
                    if (m_start_pos == 0)
                    {
                        m_terrianlist[0].m_cangive = true;
                        m_terrianlist[0].GiveGravity();
                    }
                    if (m_start_pos == 1)
                    {
                        m_terrianlist[0].GiveGravity();
                        m_terrianlist[0].m_cangive = true;
                        m_terrianlist[1].GiveGravity();
                        m_terrianlist[1].m_cangive = true;
                        m_mono3.Appear();
                    }
                    //Debug.Log("start");
                }
            }
        }
    }
}
