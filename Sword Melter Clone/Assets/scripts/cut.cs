using EzySlice;
using UnityEngine;

public class cut : MonoBehaviour
{
    public Material materialslice;
    public bool gravity, kinematic;
    public float ExplosionForce;
    public float ExplosionRadius;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("slice"))
        {
            if (other.gameObject != null)
            {
                SlicedHull sliceobj = Slice(other.gameObject, materialslice);
                if (sliceobj != null)
                {
                    GameObject slicedObjedTop = sliceobj.CreateUpperHull(other.gameObject, materialslice);
                    GameObject slicedObjedDown = sliceobj.CreateLowerHull(other.gameObject, materialslice);
                    Destroy(other.gameObject);
                    Addcompanet(slicedObjedTop, ExplosionForce);
                    Addcompanet(slicedObjedDown, ExplosionForce);
                }
            }
        }
    }

    private SlicedHull Slice(GameObject obj1, Material mat)
    {
        return obj1.Slice(transform.position, transform.right, mat);

    }
    void Addcompanet(GameObject obj1, float expForce)
    {
        obj1.AddComponent<BoxCollider>();
        var rigidbody = obj1.AddComponent<Rigidbody>();
        rigidbody.useGravity = gravity;
        rigidbody.isKinematic = kinematic;
        rigidbody.AddExplosionForce(ExplosionForce, obj1.transform.position, ExplosionRadius);
    }
}
