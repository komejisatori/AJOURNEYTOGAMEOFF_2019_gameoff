using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool m_enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<avatar_move>())
        {
            if (!collision.collider.GetComponent<avatar_health>().m_attack) {
                window_stack.Reload();
                Application.LoadLevel("Main");
            }
            else
            {
                if (this.GetComponent<enemy>())
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
