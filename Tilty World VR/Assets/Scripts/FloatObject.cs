using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public GameObject ObjectToFloat;
    public float UnitsPerSecond = 3;
    public bool Active = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Active)
        {
            ObjectToFloat.transform.Translate(Vector3.up * Time.deltaTime);
        }
    }
}
