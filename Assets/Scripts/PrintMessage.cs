using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public void Activated()
    {
        print("Activated");
        Debug.Log("Activated");
    }

    public void Desactivated()
    {
        print("Desactivated");
        Debug.Log("Desactivated");
    }
}
