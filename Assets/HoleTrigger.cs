using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HoleTrigger : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion tableStartRotation;

    [SerializeField] private TableController table;
   
    void Start()
    {
        ////Saves starting position and rotation
        startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        tableStartRotation = table.gameObject.transform.rotation;
    
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Trigger")
        {
            ////Resets it to it's starting position
            table.gameObject.transform.rotation = tableStartRotation;
            table.ResetRotation();

            collision.attachedRigidbody.velocity = Vector3.zero;
            transform.position = startPosition;

            ScoreManager.scoreEvent?.Invoke(collision.GetComponent<ScoreTrigger>().score);
        }
    }  
    
}
