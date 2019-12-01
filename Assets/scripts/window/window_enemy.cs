using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public win3_block m_block;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void delete_block()
    {
        m_block.gameObject.SetActive(false);
    }
}
