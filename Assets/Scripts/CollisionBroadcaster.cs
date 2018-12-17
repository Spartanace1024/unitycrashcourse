using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBroadcaster : MonoBehaviour {
    public event Action<GameObject> OnCollision;
    public List<string> validCollisionTags;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        foreach (var tag in validCollisionTags) {
            if (collision.gameObject.CompareTag(tag)) {
                OnCollision?.Invoke(collision.gameObject);
                return;
            }
        }
    }
}
