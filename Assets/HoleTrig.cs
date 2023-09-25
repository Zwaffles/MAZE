using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HoleTrigg : MonoBehaviour
{
    private Vector3 StartPosition;
    private Quaternion tableStartRotation;
    [SerializeField] private TableController table;
   
    void Start()
    {
        ////Saves starting position
        StartPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        tableStartRotation = table.gameObject.transform.rotation;
    
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Trigger")
        {
            ////Resets it to it's starting position
            table.gameObject.transform.rotation = tableStartRotation;
            table.ResetRotation();
            transform.position = StartPosition;
            ScoreManager.scoreEvent?.Invoke(collision.GetComponent<ScoreTrigger>().score);
        }
    }  
    
}
