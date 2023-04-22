<<<<<<< HEAD
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CenterOfMass : MonoBehaviour
{
    public Vector3 localCenterOfMass;

    private void Awake()
    {
        SetCenterOfMass();
        Destroy(this);
    }

    // Sets the RigidBody's center of mass to localCenterOfMass
    void SetCenterOfMass()
    {
        gameObject.GetComponent<Rigidbody>().centerOfMass = localCenterOfMass;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 worldCenterOfMass = transform.TransformPoint(localCenterOfMass);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.TransformPoint(localCenterOfMass), 0.1f);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.up, worldCenterOfMass - Vector3.up);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.forward, worldCenterOfMass - Vector3.forward);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.right, worldCenterOfMass - Vector3.right);
    }
}
=======
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CenterOfMass : MonoBehaviour
{
    public Vector3 localCenterOfMass;

    private void Awake()
    {
        SetCenterOfMass();
        Destroy(this);
    }

    // Sets the RigidBody's center of mass to localCenterOfMass
    void SetCenterOfMass()
    {
        gameObject.GetComponent<Rigidbody>().centerOfMass = localCenterOfMass;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 worldCenterOfMass = transform.TransformPoint(localCenterOfMass);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.TransformPoint(localCenterOfMass), 0.1f);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.up, worldCenterOfMass - Vector3.up);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.forward, worldCenterOfMass - Vector3.forward);
        Gizmos.DrawLine(worldCenterOfMass + Vector3.right, worldCenterOfMass - Vector3.right);
    }
}
>>>>>>> main
