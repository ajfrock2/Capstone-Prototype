using UnityEngine;

namespace BenchmarkTasks.CircularTiltMaze
{
    [RequireComponent(typeof(Collider))]
    public class ExitHoleTrigger : MonoBehaviour
    {
        [SerializeField] private string ballTag = "Player";
        [SerializeField] private string winMessage = "Maze Complete";

        private void Reset()
        {
            Collider col = GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ballTag))
            {
                Debug.Log(winMessage);
            }
        }
    }
}

