using UnityEngine;

public sealed class Ball : MonoBehaviour {

    public float Radius = 1f;
    public Vector3 Velocity = Vector3.zero;

    public Vector3 CollisionVelocity = Vector3.zero;
    public Vector3 Correction = Vector3.zero;

    public void Move(float deltaTime) {
        transform.position = transform.position + Velocity * deltaTime;
    }

    public void CheckCollision(Ball other) {
        if (IsCollided(other)) {
            var delta = transform.position - other.transform.position;
            var normal = delta.normalized;
            Correction = (delta - normal * (Radius + other.Radius)) * -0.5f;
            var projection = Vector3.Dot(Velocity, normal);
            var impulseVelocity = -normal * projection;
            CollisionVelocity += impulseVelocity;
            other.CollisionVelocity -= impulseVelocity;
        }
    }

    public void ApplyCollision() {
        Velocity += CollisionVelocity;
        CollisionVelocity = Vector3.zero;

        transform.position += Correction;
        Correction = Vector3.zero;
    }

    public bool IsCollided(Ball other) {
        var actualDistance = Vector3.Distance(other.transform.position, transform.position);
        var minimalDistance = Radius + other.Radius;
        return (actualDistance < minimalDistance);
    }

    public void CheckBordersCollision(Rect borders) {
        var position = transform.position;
        if (position.x < borders.xMin + Radius) { // right
            position.x = borders.xMin + Radius;
            Velocity.x = -Velocity.x;
        }
        if (position.x > borders.xMax - Radius) { // left
            position.x = borders.xMax - Radius;
            Velocity.x = -Velocity.x;
        }
        if (position.y < borders.yMin + Radius) { // bottom
            position.y = borders.yMin + Radius;
            Velocity.y = -Velocity.y;
        }
        if (position.y > borders.yMax - Radius) { // top
            position.y = borders.yMax - Radius;
            Velocity.y = -Velocity.y;
        }
        transform.position = position;
    }
}
