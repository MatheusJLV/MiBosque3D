using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EventsDictionary {
    public string eventName;
    public UnityEvent eventToAdd= new UnityEvent();
}