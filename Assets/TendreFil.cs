using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TendreFil : MonoBehaviour
{
    public float maxLength = 10.0f;
    public Transform debut;
    public Transform fin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float length = (fin.position - debut.position).magnitude;
        Debug.Log(length);
        if (length < maxLength)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, length, this.gameObject.transform.localScale.z);
            this.gameObject.transform.localPosition = new Vector3(0, length / 2, 0);
        }
    }
}
