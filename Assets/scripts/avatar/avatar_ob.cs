using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_ob : MonoBehaviour
{
    // Start is called before the first frame update
    public avatar_move m_avatar;
    
    //同一个场景里Y不变。
    void Start()
    {
        this.gameObject.transform.position = new Vector3(m_avatar.gameObject.transform.position.x, m_avatar.gameObject.transform.position.y+100
            ,this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(m_avatar.gameObject.transform.position.x, m_avatar.gameObject.transform.position.y+100
            , this.gameObject.transform.position.z);
    }
}
