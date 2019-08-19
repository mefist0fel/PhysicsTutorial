using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AngryBird : MonoBehaviour {
    public float impactTreshold = 10;

    void Start() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.relativeVelocity.magnitude > impactTreshold) {
            Destroy(gameObject);
        }
    }
}
