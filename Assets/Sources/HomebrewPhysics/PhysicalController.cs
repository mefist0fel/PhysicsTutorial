using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class PhysicalController : MonoBehaviour {
    [Header("Generation params")]
    public Ball ballPrefab;
    public float MinRadius = 1f;
    public float MaxRadius = 1f;
    public int Count = 20;

    [Header("Physical props")]
    public Rect borders = new Rect(-10, -10, 20, 20);
    public Vector3 gravity = Vector3.zero;

    public List<Ball> balls = new List<Ball>();

    private void Start() {
        for (int i = 0; i < Count; i++) {
            var position = new Vector2(Random.Range(borders.xMin, borders.xMax), Random.Range(borders.yMin, borders.yMax));
            var velocity = Random.insideUnitSphere * 10;
            var radius = Random.Range(MinRadius, MaxRadius);
            balls.Add(CreateBall(ballPrefab, position, velocity, radius));
        }
    }

    private void Update() {
        foreach (var ball in balls)
            ball.Velocity += gravity * Time.deltaTime;

        foreach (var ball in balls)
            ball.Move(Time.deltaTime);


        foreach (var ballA in balls) {
            foreach (var ballB in balls) {
                if (ballA != ballB) {
                    ballA.CheckCollision(ballB);
                }
            }
        }

        foreach (var ball in balls)
            ball.ApplyCollision();

        foreach (var ball in balls)
            ball.CheckBordersCollision(borders);

    }


    private Ball CreateBall(Ball prefab, Vector2 position, Vector2 velocity, float radius = 1f) {
        var ball = Instantiate(prefab, transform);
        ball.Velocity = velocity;
        ball.Radius = radius;
        ball.transform.position = position;
        ball.transform.localScale = Vector3.one * radius;
        return ball;
    }


    private void OnDrawGizmos() {
        // Draw borders
        var topLeft  = new Vector3(borders.xMin, borders.yMax);
        var topRight = new Vector3(borders.xMax, borders.yMax);
        var bottomLeft = new Vector3(borders.xMin, borders.yMin);
        var bottomRight = new Vector3(borders.xMax, borders.yMin);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
