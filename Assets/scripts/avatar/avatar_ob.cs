using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_ob : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 m_targetpos;
    private Transform m_follow;
    public float distanceZ;
    public float distanceY;
    //同一个场景里Y不变。
    void Start()
    {
        m_follow = GameObject.FindWithTag("Player").transform;
        transform.position = m_follow.position - new Vector3(0, distanceY, distanceZ);
    }

    // Update is called once per frame
    void Update()
    {
        //m_targetpos = m_follow.position - new Vector3(0, distanceY, distanceZ);
        //transform.position = m_targetpos;
    }
}
