using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class TopDownVehicleController : MonoBehaviour {
    public float speed = 10f;
    public float rotationSpeed = 10f;
    public Rigidbody2D rigidbody2d;


    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        ControlMove();
    }

    private void ControlMove() {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.down;

        rigidbody2d.MovePosition(transform.position + transform.rotation * moveDirection * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            rigidbody2d.MoveRotation(rigidbody2d.rotation - rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            rigidbody2d.MoveRotation(rigidbody2d.rotation + rotationSpeed * Time.deltaTime);

    }
}
