using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector2 deadZone = new Vector2(1f , 1f); // X and Y deadzone in world units

    private Vector3 _offset; 
    
    
    void Start()
    {
        _offset = transform.position - target.position;
        
    }

   
    void LateUpdate()
    {
        Vector3 targetPos = target.position + _offset;
        Vector3 diff = transform.position - targetPos;

        if (Mathf.Abs(diff.x) > deadZone.x || Mathf.Abs(diff.y) > deadZone.y)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
            newPos.z = transform.position.z; // lock z
            transform.position = newPos;
        }
    }
}
