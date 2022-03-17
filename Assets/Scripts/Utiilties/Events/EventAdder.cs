using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventAdder : MonoBehaviour {
    public EventsDictionary[] events;

    private void OnEnable(){
        AddEventsToManager();      
    }

    private void OnDisable() {
        RemoveEventsFromManager();
    }

    void AddEventsToManager(){
        foreach(EventsDictionary ed in events){
            EventManager.StartListening(ed);
        }
    }

    void RemoveEventsFromManager(){
        foreach(EventsDictionary ed in events){
            EventManager.StopListening(ed);
        }
    }

}