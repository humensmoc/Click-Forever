using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static Ground instance;
    private void Awake()
    {
        instance = this;
    }
    
    
}
