using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class TopDownStarShipController : MonoBehaviour {
    public float moveForce = 10f;
    public float rotationForce = 50f;
    public Rigidbody2D rigidbody2d;


    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        ControlMove();
    }

    private void ControlMove() {
        if (Input.GetKey(KeyCode.W))
            rigidbody2d.AddForce(transform.rotation * Vector3.up * moveForce);
        if (Input.GetKey(KeyCode.S))
            rigidbody2d.AddForce(transform.rotation * Vector3.down * moveForce);

        if (Input.GetKey(KeyCode.D))
            rigidbody2d.AddTorque(-rotationForce * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            rigidbody2d.AddTorque( rotationForce * Time.deltaTime);

    }
}
