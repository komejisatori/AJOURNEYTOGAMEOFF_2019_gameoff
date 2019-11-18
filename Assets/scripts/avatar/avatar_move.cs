using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_move : MonoBehaviour
{
    private Rigidbody2D m_rig;
    private Transform m_camera;
    public int m_speed_horizon;
    public int m_speed_verical; // jump force
    public float distanceY;
    public int m_z_index;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {
        m_rig = this.GetComponent<Rigidbody2D>();
        m_camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float speed_temp = Input.GetAxis("Horizontal");
        speed_temp = speed_temp * m_speed_horizon;
        m_rig.velocity = new Vector2(speed_temp, m_rig.velocity.y);
        float cx = m_rig.position.x;
        float cy = m_camera.position.y; 
        if (Input.GetKeyDown(KeyCode.J) && m_rig.velocity.y == 0)
        {
            m_rig.AddForce(new Vector2(0, m_speed_verical));
        }
        if(m_rig.velocity.y == 0)
        {
            cy = m_rig.position.y - distanceY;
        }
        //m_camera.position = Vector3.Lerp(m_camera.position,  new Vector3(cx, cy, m_camera.position.z), smooth * Time.deltaTime);

    }
}
