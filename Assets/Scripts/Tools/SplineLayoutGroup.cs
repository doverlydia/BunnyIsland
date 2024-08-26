using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public enum Alignment
{
    Bottom,
    Center,
    Top
}

[ExecuteAlways]
class SplineLayoutGroup : MonoBehaviour
{
    [SerializeField]
    SplineContainer splineContainer;

    [SerializeField, Range(0, 1)]
    float startT = 0f;

    [SerializeField, Range(0, 1)]
    float endT = 1f;

    [SerializeField]
    bool distributeEvenly = true;

    [SerializeField, Range(0, 1)]
    float objectSpacing = 0.1f;

    [SerializeField]
    Alignment alignment = Alignment.Center;

    void Update()
    {
        LayoutObjectsAlongSpline();
    }

    void LayoutObjectsAlongSpline()
    {
        if (splineContainer == null || splineContainer.Spline == null) return;

        int childCount = transform.childCount;
        if (childCount == 0) return;

        float step = distributeEvenly ? (endT - startT) / Mathf.Max(childCount - 1, 1) : objectSpacing;

        for (int i = 0; i < childCount; i++)
        {
            var child = transform.GetChild(i);
            float t = Mathf.Clamp01(startT + step * i);

            SplineUtility.Evaluate(splineContainer.Spline, t, out float3 position, out float3 tangent, out float3 up);

            var childBounds = child.GetComponent<Renderer>().bounds;
            float alignmentOffset = 0f;

            switch (alignment)
            {
                case Alignment.Bottom:
                    alignmentOffset = -childBounds.extents.y;
                    break;
                case Alignment.Center:
                    alignmentOffset = 0f;
                    break;
                case Alignment.Top:
                    alignmentOffset = childBounds.extents.y;
                    break;
            }

            child.position = splineContainer.transform.TransformPoint(position) + splineContainer.transform.TransformDirection(up) * alignmentOffset;
            child.rotation = Quaternion.LookRotation(splineContainer.transform.TransformDirection(tangent), splineContainer.transform.TransformDirection(up));
        }
    }
}

