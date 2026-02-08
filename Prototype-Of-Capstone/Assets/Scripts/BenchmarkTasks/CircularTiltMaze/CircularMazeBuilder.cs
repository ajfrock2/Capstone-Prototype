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
            public float thickness = 0.2f;
            public float depth = 0.5f;
            public float segmentLength = 0.5f;
        }

        [System.Serializable]
        public class RadialWall
        {
            public string name = "Radial";
            public float angleDeg = 0f;
            public float innerRadius = 1f;
            public float outerRadius = 2f;
            public float thickness = 0.2f;
            public float depth = 0.5f;
        }

        [Header("Build")]
        [SerializeField] private bool buildOnStart = true;
        [SerializeField] private bool clearExisting = true;

        [Header("Maze Dimensions")]
        [SerializeField] private float mazeRadius = 5f;
        [SerializeField] private float mazeDepth = 0.6f;
        [SerializeField] private float stopThickness = 0.1f;
        [SerializeField] private bool addFrontBackStops = true;

        [Header("Materials")]
        [SerializeField] private Material stopMaterial;

        [Header("Layout - Ring Arcs")]
        [SerializeField] private RingArc[] ringArcs = new RingArc[]
        {
            // Outer ring (gap 350°–20°)
            new RingArc { name = "Outer_A", radius = 5.0f, startAngleDeg = 20f, endAngleDeg = 180f, thickness = 0.25f, depth = 0.6f, segmentLength = 0.5f },
            new RingArc { name = "Outer_B", radius = 5.0f, startAngleDeg = 180f, endAngleDeg = 350f, thickness = 0.25f, depth = 0.6f, segmentLength = 0.5f },

            // Ring 1 (gap 340°–60°)
            new RingArc { name = "Ring1_A", radius = 3.5f, startAngleDeg = 60f, endAngleDeg = 180f, thickness = 0.20f, depth = 0.5f, segmentLength = 0.45f },
            new RingArc { name = "Ring1_B", radius = 3.5f, startAngleDeg = 180f, endAngleDeg = 340f, thickness = 0.20f, depth = 0.5f, segmentLength = 0.45f },

            // Ring 2 (gap 230°–270°)
            new RingArc { name = "Ring2_A", radius = 2.2f, startAngleDeg = 270f, endAngleDeg = 360f, thickness = 0.20f, depth = 0.5f, segmentLength = 0.4f },
            new RingArc { name = "Ring2_B", radius = 2.2f, startAngleDeg = 0f, endAngleDeg = 230f, thickness = 0.20f, depth = 0.5f, segmentLength = 0.4f },

            // Ring 3 (gap 110°–150°)
            new RingArc { name = "Ring3_A", radius = 1.0f, startAngleDeg = 150f, endAngleDeg = 360f, thickness = 0.20f, depth = 0.5f, segmentLength = 0.35f },
            new RingArc { name = "Ring3_B", radius = 1.0f, startAngleDeg = 0f, endAngleDeg = 110f, thickness = 0.20f, depth = 0.5f, segmentLength = 0.35f },
        };

        [Header("Layout - Radial Walls")]
        [SerializeField] private RadialWall[] radialWalls = new RadialWall[]
        {
            new RadialWall { name = "RW1", angleDeg = 60f, innerRadius = 1.0f, outerRadius = 2.2f, thickness = 0.20f, depth = 0.5f },
            new RadialWall { name = "RW2", angleDeg = 200f, innerRadius = 2.2f, outerRadius = 3.5f, thickness = 0.20f, depth = 0.5f },
            new RadialWall { name = "RW3", angleDeg = 300f, innerRadius = 3.5f, outerRadius = 5.0f, thickness = 0.20f, depth = 0.6f },
            new RadialWall { name = "RW4", angleDeg = 100f, innerRadius = 3.5f, outerRadius = 5.0f, thickness = 0.20f, depth = 0.6f },
        };

        [Header("Exit Trigger (Optional)")]
        [SerializeField] private Transform exitTrigger;
        [SerializeField] private float exitAngleDeg = 5f;
        [SerializeField] private float exitRadius = 5.0f;
        [SerializeField] private Vector3 exitTriggerSize = new Vector3(0.6f, 0.6f, 0.6f);

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
