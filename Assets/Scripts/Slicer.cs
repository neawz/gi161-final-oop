using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class Slicer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float minSliceSpeed = 100f;    // px/sec (screen space)
    [SerializeField] private float sliceRadius = 0.2f;      // world units
    [SerializeField] private float maxTrailTime = 0.15f;

    private LineRenderer lr;
    private Camera cam;
    private readonly List<Vector3> points = new();
    private float lastInputTime;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
        lr.positionCount = 0;
    }

    private void Update()
    {
        HandleInput();
        CullOldPoints();
        DrawTrail();
        DetectHits();
    }

    private void HandleInput()
    {
        bool pressing = Input.GetMouseButton(0); // รองรับ touch ผ่าน mouse ใน editor
        if (!pressing) return;

        Vector3 screenPos = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;

        points.Add(worldPos);
        lastInputTime = Time.time;
    }

    private void CullOldPoints()
    {
        // ตัดจุดที่เก่ากว่า window
        float cutoff = Time.time - maxTrailTime;
        // เก็บง่ายๆ: หากไม่มี input ล่าสุด ให้ล้าง
        if (Time.time - lastInputTime > maxTrailTime)
        {
            points.Clear();
            lr.positionCount = 0;
        }
    }

    private void DrawTrail()
    {
        lr.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
            lr.SetPosition(i, points[i]);
    }

    private void DetectHits()
    {
        if (points.Count < 2) return;

        int hitCountThisStrike = 0;
        HashSet<Fruit> hitThisFrame = new();

        for (int i = 1; i < points.Count; i++)
        {
            Vector2 a = points[i - 1];
            Vector2 b = points[i];
            float dist = Vector2.Distance(a, b);
            float speed = dist / Time.deltaTime;

            if (speed < minSliceSpeed) continue;

            RaycastHit2D[] hits = Physics2D.CircleCastAll(a, sliceRadius, (b - a).normalized, dist);
            foreach (var h in hits)
            {
                var fruit = h.collider.GetComponentInParent<Fruit>();
                if (fruit != null && hitThisFrame.Add(fruit))
                {
                    player.Slice(fruit);
                }
            }
        }

        if (hitCountThisStrike > 0)
        {
            points.Clear();
            lr.positionCount = 0;
        }
    }
}