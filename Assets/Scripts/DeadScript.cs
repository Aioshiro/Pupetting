using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScript : MonoBehaviour
{
    private float t = 0;
    public float dt = 0.03f;
    public bool go = false;
    Quaternion qf = Quaternion.Euler(90f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            this.transform.rotation = Quaternion.Lerp(Quaternion.identity, qf, t);
            t += dt;
            if (t > 1)
            {
                go = false;
            }
        }
    }

    public void Go()
    {
        go = true;
        t = 0;
    }
}
