using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ender : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite m_img;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        this.GetComponent<SpriteRenderer>().sprite = m_img;
    }
}
