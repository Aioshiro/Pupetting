using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleKnuckles : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] knuckles;
    public GameObject knucklePrefab;
    void Start()
    {
        knuckles = GameObject.FindGameObjectsWithTag("GoodBoyKnuckle");
        foreach (GameObject knuckle in knuckles)
        {
            GameObject go = GameObject.Instantiate(knucklePrefab);
            go.transform.parent = knuckle.transform;
            go.transform.localPosition = Vector3.zero;
            go.GetComponent<MeshRenderer>().material = Resources.Load<Material>("GoodBoySkin");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
