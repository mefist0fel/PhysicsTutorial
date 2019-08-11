using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class TopDownHeroController : MonoBehaviour {
    public float speed = 10f;
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
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        rigidbody2d.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
    }
}
