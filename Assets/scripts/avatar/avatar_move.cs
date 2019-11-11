using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_move : MonoBehaviour
{
    private Rigidbody2D m_rig;
    public int m_speed_horizon;
    public int m_speed_verical; // jump force
    

    // Start is called before the first frame update
    void Start()
    {
        m_rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed_temp = Input.GetAxis("Horizontal");
        
        speed_temp = speed_temp * m_speed_horizon;
        m_rig.velocity = new Vector2(speed_temp, m_rig.velocity.y);
        if (Input.GetKeyDown(KeyCode.J))
        {
            m_rig.AddForce(new Vector2(0, m_speed_verical));
        }
    }
}
