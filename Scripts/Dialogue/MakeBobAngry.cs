using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBobAngry : MonoBehaviour
{
    public void SetAngry(){
        GetComponent<Renderer>().material.color = Color.red;
    }
}