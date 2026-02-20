using UnityEngine;

namespace BenchmarkTasks.CircularTiltMaze
{
    public class CircularMazeBuilder : MonoBehaviour
    {
        [System.Serializable]
        public class RingArc
        {
            public string name = "Ring";
            public float radius = 5f;
            public float startAngleDeg = 0f;
            public float endAngleDeg = 90f;
            public float thickness = 0.2f; // Y scale (wall height)
            public float depth = 0.5f;     // Z scale (wall thickness in plane)
            public float segmentLength = 0.5f;
        }

        [System.Serializable]
        public class RadialWall
        {
            public string name = "Radial";
            public float angleDeg = 0f;
            public float innerRadius = 1f;
            public float outerRadius = 2f;
            public float thickness = 0.2f; // Y scale (wall height)
            public float depth = 0.5f;     // Z scale (wall thickness in plane)
        }

        [Header("Build")]
        [SerializeField] private bool buildOnStart = true;
        [SerializeField] private bool clearExisting = true;

        [Header("Maze Dimensions")]
        [SerializeField] private float mazeRadius = 20f;
        [SerializeField] private float mazeDepth = 1.2f;
        [SerializeField] private float stopThickness = 0.2f;
        [SerializeField] private bool addFrontBackStops = true;

        [Header("Materials")]
        [SerializeField] private Material stopMaterial;

        [Header("Layout - Ring Arcs")]
        [SerializeField] private RingArc[] ringArcs = new RingArc[]
        {
            // R1 (gap 8°–32°)
            new RingArc { name = "R1_A", radius = 2.0f, startAngleDeg = 32f, endAngleDeg = 360f, thickness = 0.70f, depth = 0.30f, segmentLength = 0.6f },
            new RingArc { name = "R1_B", radius = 2.0f, startAngleDeg = 0f, endAngleDeg = 8f, thickness = 0.70f, depth = 0.30f, segmentLength = 0.6f },

            // R2 (gap 188°–212°)
            new RingArc { name = "R2_A", radius = 4.0f, startAngleDeg = 212f, endAngleDeg = 360f, thickness = 0.70f, depth = 0.30f, segmentLength = 0.8f },
            new RingArc { name = "R2_B", radius = 4.0f, startAngleDeg = 0f, endAngleDeg = 188f, thickness = 0.70f, depth = 0.30f, segmentLength = 0.8f },

            // R3 (gap 58°–82°)
            new RingArc { name = "R3_A", radius = 6.4f, startAngleDeg = 82f, endAngleDeg = 360f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.0f },
            new RingArc { name = "R3_B", radius = 6.4f, startAngleDeg = 0f, endAngleDeg = 58f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.0f },

            // R4 (gap 238°–262°)
            new RingArc { name = "R4_A", radius = 9.2f, startAngleDeg = 262f, endAngleDeg = 360f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.2f },
            new RingArc { name = "R4_B", radius = 9.2f, startAngleDeg = 0f, endAngleDeg = 238f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.2f },

            // R5 (gap 118°–142°)
            new RingArc { name = "R5_A", radius = 12.4f, startAngleDeg = 142f, endAngleDeg = 360f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.4f },
            new RingArc { name = "R5_B", radius = 12.4f, startAngleDeg = 0f, endAngleDeg = 118f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.4f },

            // R6 (gap 288°–312°)
            new RingArc { name = "R6_A", radius = 16.0f, startAngleDeg = 312f, endAngleDeg = 360f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.6f },
            new RingArc { name = "R6_B", radius = 16.0f, startAngleDeg = 0f, endAngleDeg = 288f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.6f },

            // R7 outer wall (exit gap 96°–124°)
            new RingArc { name = "R7_A", radius = 20.0f, startAngleDeg = 124f, endAngleDeg = 360f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.8f },
            new RingArc { name = "R7_B", radius = 20.0f, startAngleDeg = 0f, endAngleDeg = 96f, thickness = 0.70f, depth = 0.30f, segmentLength = 1.8f },
        };

        [Header("Layout - Radial Walls")]
        [SerializeField] private RadialWall[] radialWalls = new RadialWall[]
        {
            new RadialWall { name = "Wall_A", angleDeg = 220f, innerRadius = 2.2f, outerRadius = 3.8f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_B", angleDeg = 350f, innerRadius = 2.2f, outerRadius = 3.8f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_C", angleDeg = 40f,  innerRadius = 4.2f, outerRadius = 6.0f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_D", angleDeg = 220f, innerRadius = 4.2f, outerRadius = 6.0f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_E", angleDeg = 40f,  innerRadius = 6.6f, outerRadius = 8.8f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_F", angleDeg = 300f, innerRadius = 6.6f, outerRadius = 8.8f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_G", angleDeg = 100f, innerRadius = 9.6f, outerRadius = 12.0f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_H", angleDeg = 280f, innerRadius = 9.6f, outerRadius = 12.0f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_I", angleDeg = 90f,  innerRadius = 12.4f, outerRadius = 16.0f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_J", angleDeg = 340f, innerRadius = 12.4f, outerRadius = 16.0f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_K", angleDeg = 80f,  innerRadius = 16.4f, outerRadius = 20.0f, thickness = 0.70f, depth = 0.30f },
            new RadialWall { name = "Wall_L", angleDeg = 320f, innerRadius = 16.4f, outerRadius = 20.0f, thickness = 0.70f, depth = 0.30f },
        };

        [Header("Exit Trigger (Optional)")]
        [SerializeField] private Transform exitTrigger;
        [SerializeField] private float exitAngleDeg = 110f;
        [SerializeField] private float exitRadius = 20.0f;
        [SerializeField] private Vector3 exitTriggerSize = new Vector3(2.0f, 0.7f, 0.6f);

        private Transform geometryRoot;

        private void Start()
        {
            if (buildOnStart)
            {
                Build();
            }
        }

        [ContextMenu("Build Maze")]
        public void Build()
        {
            EnsureGeometryRoot();
            if (clearExisting)
            {
                ClearChildren(geometryRoot);
            }

            if (addFrontBackStops)
            {
                BuildFrontBackStops();
            }

            for (int i = 0; i < ringArcs.Length; i++)
            {
                BuildRingArc(ringArcs[i]);
            }

            for (int i = 0; i < radialWalls.Length; i++)
            {
                BuildRadialWall(radialWalls[i]);
            }

            PlaceExitTrigger();
        }

        private void EnsureGeometryRoot()
        {
            if (geometryRoot != null)
            {
                return;
            }

            Transform existing = transform.Find("Geometry");
            if (existing != null)
            {
                geometryRoot = existing;
                return;
            }

            GameObject root = new GameObject("Geometry");
            root.transform.SetParent(transform, false);
            geometryRoot = root.transform;
        }

        private void BuildFrontBackStops()
        {
            float diameter = mazeRadius * 2f;
            Vector3 size = new Vector3(diameter, diameter, stopThickness);

            GameObject back = CreateCube("BackStop", new Vector3(0f, 0f, -mazeDepth * 0.5f - stopThickness * 0.5f), Quaternion.identity, size, stopMaterial);
            GameObject front = CreateCube("FrontStop", new Vector3(0f, 0f, mazeDepth * 0.5f + stopThickness * 0.5f), Quaternion.identity, size, stopMaterial);

            back.transform.SetParent(geometryRoot, false);
            front.transform.SetParent(geometryRoot, false);
        }

        private void BuildRingArc(RingArc arc)
        {
            float arcAngle = GetArcAngle(arc.startAngleDeg, arc.endAngleDeg);
            float arcLength = Mathf.Deg2Rad * arcAngle * arc.radius;
            int segments = Mathf.Max(1, Mathf.CeilToInt(arcLength / Mathf.Max(0.01f, arc.segmentLength)));
            float step = arcAngle / segments;

            for (int i = 0; i < segments; i++)
            {
                float angle = arc.startAngleDeg + step * (i + 0.5f);
                float radians = angle * Mathf.Deg2Rad;

                float segmentLength = 2f * arc.radius * Mathf.Sin((step * Mathf.Deg2Rad) * 0.5f);
                Vector3 pos = new Vector3(Mathf.Cos(radians) * arc.radius, Mathf.Sin(radians) * arc.radius, 0f);
                Quaternion rot = Quaternion.Euler(0f, 0f, angle + 90f);
                Vector3 scale = new Vector3(segmentLength, arc.thickness, arc.depth);

                GameObject segment = CreateCube(arc.name + "_Seg" + i, pos, rot, scale, null);
                segment.transform.SetParent(geometryRoot, false);
            }
        }

        private void BuildRadialWall(RadialWall wall)
        {
            float length = Mathf.Max(0.01f, wall.outerRadius - wall.innerRadius);
            float midRadius = (wall.outerRadius + wall.innerRadius) * 0.5f;
            float radians = wall.angleDeg * Mathf.Deg2Rad;
            Vector3 pos = new Vector3(Mathf.Cos(radians) * midRadius, Mathf.Sin(radians) * midRadius, 0f);
            Quaternion rot = Quaternion.Euler(0f, 0f, wall.angleDeg);
            Vector3 scale = new Vector3(length, wall.thickness, wall.depth);

            GameObject segment = CreateCube(wall.name, pos, rot, scale, null);
            segment.transform.SetParent(geometryRoot, false);
        }

        private void PlaceExitTrigger()
        {
            if (exitTrigger == null)
            {
                return;
            }

            float radians = exitAngleDeg * Mathf.Deg2Rad;
            Vector3 localPos = new Vector3(Mathf.Cos(radians) * exitRadius, Mathf.Sin(radians) * exitRadius, 0f);
            exitTrigger.localPosition = localPos;
            exitTrigger.localRotation = Quaternion.Euler(0f, 0f, exitAngleDeg);

            BoxCollider box = exitTrigger.GetComponent<BoxCollider>();
            if (box != null)
            {
                box.isTrigger = true;
                box.size = exitTriggerSize;
            }
        }

        private static float GetArcAngle(float startDeg, float endDeg)
        {
            float delta = endDeg - startDeg;
            if (delta < 0f)
            {
                delta += 360f;
            }
            return Mathf.Clamp(delta, 0f, 360f);
        }

        private GameObject CreateCube(string name, Vector3 localPos, Quaternion localRot, Vector3 localScale, Material materialOverride)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.name = name;
            obj.transform.localPosition = localPos;
            obj.transform.localRotation = localRot;
            obj.transform.localScale = localScale;

            if (materialOverride != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sharedMaterial = materialOverride;
                }
            }

            return obj;
        }

        private static void ClearChildren(Transform parent)
        {
            int count = parent.childCount;
            for (int i = count - 1; i >= 0; i--)
            {
                Transform child = parent.GetChild(i);
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    Object.DestroyImmediate(child.gameObject);
                }
                else
                {
                    Object.Destroy(child.gameObject);
                }
#else
                Object.Destroy(child.gameObject);
#endif
            }
        }
    }
}
