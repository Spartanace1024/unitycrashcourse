using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnterBroadcaster : MonoBehaviour {
    public event Action<Collision2D> OnCollisionEnter;
    public List<string> validCollisionTags;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        foreach (var tag in validCollisionTags) {
            if (collision.gameObject.CompareTag(tag)) {
                OnCollisionEnter?.Invoke(collision);
                return;
            }
        }
    }
}
