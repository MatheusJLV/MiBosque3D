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
        Debug.Log("agregando eventos");
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