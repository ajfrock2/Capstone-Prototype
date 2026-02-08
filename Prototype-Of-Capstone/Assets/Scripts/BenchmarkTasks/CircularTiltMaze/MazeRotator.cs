using UnityEngine;

namespace BenchmarkTasks.CircularTiltMaze
{
    public class MazeRotator : MonoBehaviour
    {
        [SerializeField] private float rotationSpeedDegPerSec = 45f;

        private void FixedUpdate()
        {
            float input = 0f;
            if (Input.GetKey(KeyCode.A))
            {
                input += 1f; // Counterclockwise
            }
            if (Input.GetKey(KeyCode.D))
            {
                input -= 1f; // Clockwise
            }

            if (Mathf.Abs(input) > 0.001f)
            {
                float delta = input * rotationSpeedDegPerSec * Time.fixedDeltaTime;
                transform.Rotate(Vector3.forward, delta, Space.World);
            }
        }
    }
}

