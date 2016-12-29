using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RotateObject : MonoBehaviour {

    public GameObject CameraRig;
    public GameObject ObjectToRotate;
    public short DegreesPerSecond = 3;
    public bool Active = false;

    private DateTime _startTime;

    private ItsAlmostAStack<GameObject> _rotateAround = new ItsAlmostAStack<GameObject>();

	// Use this for initialization
	void Start () {
        _startTime = DateTime.Now;
        var o = CameraRig.GetComponentsInChildren<VRTK_InteractGrab>(true);
        _rotateAround.Push(CameraRig);
        foreach (var item in o)
        {
            item.ControllerGrabInteractableObject += RotateObject_GripPressed;
            item.ControllerUngrabInteractableObject += RotateObject_GripReleased;
        }
    }

    private void RotateObject_GripPressed(object sender, ObjectInteractEventArgs e)
    {
        _rotateAround.Push(((VRTK_InteractGrab)sender).gameObject);
    }

    private void RotateObject_GripReleased(object sender, ObjectInteractEventArgs e)
    {
        _rotateAround.Remove(((VRTK_InteractGrab)sender).gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (Active)
        {
            var rotateAround = _rotateAround.Peek();
            ObjectToRotate.transform.RotateAround(rotateAround.transform.position, Vector3.back, DegreesPerSecond * Time.deltaTime);
        }
	}
}

public class ItsAlmostAStack<T>
{
    private List<T> items = new List<T>();

    public void Push(T item)
    {
        items.Add(item);
    }
    public T Pop()
    {
        if (items.Count > 0)
        {
            T temp = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return temp;
        }
        else
            return default(T);
    }
    public T Peek()
    {
        if (items.Count > 0)
        {
            return items[items.Count - 1];
        }
        else
            return default(T);
    }
    public void Remove(T item)
    {
        items.Remove(item);
    }
}
