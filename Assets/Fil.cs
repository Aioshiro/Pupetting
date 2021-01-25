using System;
using UnityEngine;

public class Fil : MonoBehaviour
{
    public float maxLength;
    public GameObject arrivee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = arrivee.transform.position - this.transform.position;
        if (distance.magnitude < maxLength)
        {
            this.transform.localScale -= new Vector3(0, 0, this.transform.localScale.z);
            this.transform.localScale += new Vector3(0, 0, 10*distance.magnitude);
        }
        else
        {
            this.transform.localScale -= new Vector3(0, 0, this.transform.localScale.z);
            this.transform.localScale += new Vector3(0, 0, 10*maxLength);
        }
    }
}
