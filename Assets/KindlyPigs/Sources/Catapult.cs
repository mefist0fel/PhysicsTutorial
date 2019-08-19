using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Catapult : MonoBehaviour {

    public Camera controlCamera;
    public Rigidbody2D bulletPrefab;
    public Transform marker;

    public float maxDistance = 3f;
    public float maxPower = 20f;
    public float bulletLifeTime = 10f;

    void Start() {

    }

    void Update() {
        var mousePoint = controlCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = 0;

        Vector3 delta = transform.position - mousePoint;
        var distance = delta.magnitude;
        if (distance > maxDistance)
            distance = maxDistance;

        var normalizedDelta = delta.normalized;

        marker.position = transform.position + normalizedDelta * distance;

        if (Input.GetMouseButtonDown(0)) {
            Fire(transform.position, normalizedDelta * (distance / maxDistance) * maxPower);
        }
    }

    private void Fire(Vector3 position, Vector3 direction) {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = position;
        bullet.position = position;
        bullet.velocity = direction;
        Destroy(bullet.gameObject, bulletLifeTime);
    }
}
