using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    public ParticleSystem collectableParticles;

    void Start()
    {
        EmitParticles(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CollectObject();
        }
    }

    void CollectObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            CollectableObject obj = hit.transform.GetComponent<CollectableObject>();
            if (obj != null)
            {
                obj.GetCollected();
                EmitParticles(obj.transform.position, 10);
                if (obj.target.IsCompleted() && obj.target.isMovable)
                    obj.target.GetComponent<MovableObject>().ActiveMovement(null);                
            }
            TargetCollectObject targetObj = hit.transform.GetComponent<TargetCollectObject>();
            if (targetObj != null)
            {
                if (targetObj.isInteractive)
                {
                    targetObj.UpdateCounter();
                    if (targetObj.IsCompleted())
                        EmitParticles(targetObj.transform.position, 30);
                }
                    
            }

        }
    }

    void EmitParticles(Vector3 position, int count)
    {
        collectableParticles.transform.position = position;
        collectableParticles.Play();
    }

    void EmitParticles(int count)
    {
        collectableParticles.Emit(count);
    }
}
