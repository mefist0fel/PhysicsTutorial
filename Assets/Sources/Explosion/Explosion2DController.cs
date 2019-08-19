using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion2DController : MonoBehaviour {
    public Camera controlCamera;
    public float explosionRadius = 10f;
    public float explosionForce = 10f;
    public Transform marker = null;

    private void Update() {
        var point = controlCamera.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;
        if (Input.GetMouseButtonDown(0)) {
            ExplodeInPoint(point);
        }
        if (marker != null)
            marker.position = point;
    }

    private void ExplodeInPoint(Vector2 position) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, explosionRadius);
        foreach (Collider2D hit in colliders) {
            Rigidbody2D rigidbody = hit.GetComponent<Rigidbody2D>();

            if (rigidbody != null)
                AddExplosionForce(rigidbody, explosionForce, position, explosionRadius);
        }
    }

    private void AddExplosionForce(Rigidbody2D body, float explosionForce, Vector2 explosionPosition, float explosionRadius) {
        var direction = body.position - explosionPosition;
        float wearoff = 1 - (direction.magnitude / explosionRadius);
        body.AddForce(direction.normalized * explosionForce * wearoff);
    }
}
