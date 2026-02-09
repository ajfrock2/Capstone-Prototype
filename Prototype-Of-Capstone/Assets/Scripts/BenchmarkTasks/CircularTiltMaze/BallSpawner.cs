using UnityEngine;

namespace BenchmarkTasks.CircularTiltMaze
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Transform mazeSpace;
        [SerializeField] private bool spawnOnStart = true;
        [SerializeField] private GameObject ballPrefab;

        [Header("Start Position (Maze Local)")]
        [SerializeField] private Vector3 startLocalPosition = new Vector3(0f, 0.2f, 0f);

        [Header("Ball Settings")]
        [SerializeField] private float ballRadius = 0.18f;
        [SerializeField] private float ballMass = 1.0f;
        [SerializeField] private float ballDrag = 0.05f;
        [SerializeField] private float ballAngularDrag = 0.05f;
        [SerializeField] private CollisionDetectionMode collisionDetection = CollisionDetectionMode.ContinuousDynamic;
        [SerializeField] private RigidbodyInterpolation interpolation = RigidbodyInterpolation.Interpolate;
        [SerializeField] private string ballTag = "Player";

        private GameObject spawnedBall;

        private void Start()
        {
            if (spawnOnStart)
            {
                Spawn();
            }
        }

        [ContextMenu("Spawn Ball")]
        public void Spawn()
        {
            if (spawnedBall != null)
            {
                Destroy(spawnedBall);
            }

            Vector3 worldPos = mazeSpace != null ? mazeSpace.TransformPoint(startLocalPosition) : startLocalPosition;

            if (ballPrefab != null)
            {
                spawnedBall = Instantiate(ballPrefab, worldPos, Quaternion.identity);
            }
            else
            {
                spawnedBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                spawnedBall.transform.position = worldPos;
                SphereCollider sphere = spawnedBall.GetComponent<SphereCollider>();
                if (sphere != null)
                {
                    sphere.radius = ballRadius;
                }
            }

            spawnedBall.name = "Ball";
            spawnedBall.tag = ballTag;

            Rigidbody rb = spawnedBall.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = spawnedBall.AddComponent<Rigidbody>();
            }

            rb.mass = ballMass;
            rb.linearDamping = ballDrag;
            rb.angularDamping = ballAngularDrag;
            rb.collisionDetectionMode = collisionDetection;
            rb.interpolation = interpolation;
            rb.useGravity = true;
        }
    }
}
