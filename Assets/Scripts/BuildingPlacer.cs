using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField]
    Color enableColor = Color.blue, disableColor = Color.red;
    [SerializeField]
    Vector3 positionOffset, boxOffset, boxSize;
    [SerializeField]
    float maxNavMeshDistace = 1;
    [SerializeField]
    LayerMask boxLayerMask=-1;

    Vector3 startPoint;
    new Renderer renderer;
    NavMeshHit navHit;
    NavMeshPath navPath;

    private void Awake()
    {
        startPoint = transform.position;
        renderer = GetComponentInChildren<Renderer>(true);
        navPath = new NavMeshPath();
    }

    private void Update()
    {
        renderer.sharedMaterial.color = CanBuildHere() ? enableColor : disableColor;
    }

    public bool CanBuildHere()
    {
        if (!Physics.CheckBox(transform.position + boxOffset, boxSize/2, transform.rotation, boxLayerMask))
        {
            if (NavMesh.SamplePosition(transform.position, out navHit, maxNavMeshDistace, NavMesh.AllAreas))
            {
                if (NavMesh.CalculatePath(startPoint, transform.position, NavMesh.AllAreas, navPath))
                {
                    for (int i = 0; i < navPath.corners.Length-1; i++)
                    {
                        Debug.DrawLine(navPath.corners[i], navPath.corners[i + 1], Color.cyan);
                    }
                    return navPath.status == NavMeshPathStatus.PathComplete;
                }

            }
        }
        return false;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position + positionOffset;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + boxOffset, boxSize);
    }
}
