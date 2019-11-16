using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_HP = 100;
    public int m_speed = 20;
    public int m_speed_vertical = 10;
    public int m_type = 0; //0 for attacking players 1 for not attacking players
    public bool m_hidden = false;
    public int m_moverange = 40;
    public window_select m_window_belong_to;
    private Vector2 m_init_pos;
    private int m_jump_height = 2;
    private Rigidbody2D m_rig;
    public float m_think_time;
    private float m_last_think_time;

    void Start()
    {
        // if hidden then cannot be seen
        m_init_pos = this.transform.position;
        m_rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_window_belong_to.m_z_index == 0)
        {
            if (SearchForAvatar())
            {
                MoveTowardsAvatar();
            }
            else
               MoveAround();
        }
        else
        {
            MoveAround();
        }
    }

    bool SearchForAvatar()
    {
        Collider2D[] cls = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(5, 5), 0);
        foreach (Collider2D c in cls)
        
            if (c.GetComponentInParent<avatar_move>())
                return true;
        
        return false;       
    }

    void MoveAround()
    {
        if (Mathf.Abs(this.transform.position.x - m_init_pos.x) > m_moverange)
            Move(m_init_pos);
        else
        {
            if (Time.time - m_last_think_time > m_think_time)
            {
                m_last_think_time = Time.time;
                int Rnd = Random.Range(-m_moverange, m_moverange);
                Move(new Vector2(m_init_pos.x + Rnd, 0));
            }
        }
    }

    void Jump()
    {
        m_rig.AddForce(new Vector2(0, m_speed_vertical));
    }

    void Move(Vector2 pos)
    {
        if (this.transform.position.x < pos.x)
            m_rig.velocity = new Vector2(m_speed, m_rig.velocity.y);
        else
            m_rig.velocity = new Vector2(-m_speed, m_rig.velocity.y);
    }

    void MoveTowardsAvatar()
    {
        avatar_move avatar = FindObjectOfType<avatar_move>();
        float height = avatar.transform.position.y - this.transform.position.y;
        Move(avatar.transform.position);
        if (height > m_jump_height)
            Jump();

    }
}
