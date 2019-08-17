using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion3DController : MonoBehaviour {
    public Camera controlCamera;
    public float explosionRadius = 10f;
    public float explosionForce = 10f;
    public float upwardsModifier = 3f;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var ray = controlCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                ExplodeInPoint(hit.point);
            }
        }
    }

    private void ExplodeInPoint(Vector3 position) {
        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius);
        foreach (Collider hit in colliders) {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(explosionForce, position, explosionRadius, upwardsModifier);
        }
    }
}
