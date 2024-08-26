using UnityEngine;

class SnapToFloor : MonoBehaviour
{
    [SerializeField]
    LayerMask _floorLayer;

    void Start()
    {
        SnapObjectToFloor();
    }

    void SnapObjectToFloor()
    {
        // Get the object's mesh renderer or collider to calculate the bounds
        Renderer objectRenderer = GetComponent<Renderer>();
        Collider objectCollider = GetComponent<Collider>();

        if (objectRenderer != null)
        {
            // Calculate the bottom of the object's bounding box
            float objectBottom = objectRenderer.bounds.min.y;

            // Raycast down from the center of the object's bounds to find the floor
            Vector3 rayOrigin = new Vector3(transform.position.x, objectBottom + 0.1f, transform.position.z);
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, Vector3.down, out hit, Mathf.Infinity, _floorLayer))
            {
                // The y-coordinate of the floor at the hit point
                float floorY = hit.point.y;

                // Calculate the distance to move the object down so the bottom touches the floor
                float distanceToFloor = objectBottom - floorY;

                // Move the object down
                transform.position -= new Vector3(0, distanceToFloor, 0);
            }
            else
            {
                Debug.LogError("Floor not detected. Make sure the floor is correctly tagged or layered.");
            }
        }
        else if (objectCollider != null)
        {
            // Calculate the bottom of the object's bounding box
            float objectBottom = objectCollider.bounds.min.y;

            // Raycast down from the center of the object's bounds to find the floor
            Vector3 rayOrigin = new Vector3(transform.position.x, objectBottom + 0.1f, transform.position.z);
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, Vector3.down, out hit, Mathf.Infinity, _floorLayer))
            {
                // The y-coordinate of the floor at the hit point
                float floorY = hit.point.y;

                // Calculate the distance to move the object down so the bottom touches the floor
                float distanceToFloor = objectBottom - floorY;

                // Move the object down
                transform.position -= new Vector3(0, distanceToFloor, 0);
            }
            else
            {
                Debug.LogError("Floor not detected. Make sure the floor is correctly tagged or layered.");
            }
        }
        else
        {
            Debug.LogError("No Renderer or Collider attached to the object. Cannot snap to floor.");
        }
    }
}
