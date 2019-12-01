using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getmono : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<avatar_get>())
        {
            collision.GetComponent<avatar_get>().Getmono(type);
            this.gameObject.SetActive(false);

        }
    }
}
