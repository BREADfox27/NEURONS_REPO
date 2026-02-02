using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    LayerMask mask;
    public float distance = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mask = LayerMask.GetMask("Raycast Detect");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            if (hit.collider.tag == "DeadBody")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {

                }
            }
        }
    }
}
