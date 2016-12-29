using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayEngine : MonoBehaviour {

    public float SecondsUntilFloat = 10f;
    public float SecondsUntilFloatStop = 20f;
    public float SecondsUntilSpin = 22f;

    private DateTime _startTime;
    private RotateObject _rotateObject;
    private FloatObject _floatObject;

	// Use this for initialization
	void Start () {
        _startTime = DateTime.Now;
        _rotateObject = FindObjectOfType<RotateObject>();
        _floatObject = FindObjectOfType<FloatObject>();


        Invoke("BeginFloating", SecondsUntilFloat);
        Invoke("StopFloating", SecondsUntilFloatStop);
        Invoke("BeginSpinning", SecondsUntilSpin);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void BeginFloating()
    {
        _floatObject.Active = true;
    }

    void StopFloating()
    {
        _floatObject.Active = false;
    }

    void BeginSpinning()
    {
        _rotateObject.Active = true;
    }
}
