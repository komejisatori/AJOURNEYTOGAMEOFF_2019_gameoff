using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    private float m_start_x;
    private float m_start_y;
    void Start()
    {
        m_start_x = this.gameObject.transform.position.x;
        m_start_y = this.gameObject.transform.position.y;
        this.gameObject.transform.position = new Vector3(10000, 10000, this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetIn()
    {
        this.gameObject.transform.position = new Vector3(m_start_x, m_start_y, this.gameObject.transform.position.z);
    }

    public void GetOut()
    {
        this.gameObject.transform.position = new Vector3(10000, 10000, this.gameObject.transform.position.z);
    }

    public void Show(int index)
    {
        if(index == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = img1;
        }
        if (index == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = img2;
        }
        if(index == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = img3;
        }
    }

}
