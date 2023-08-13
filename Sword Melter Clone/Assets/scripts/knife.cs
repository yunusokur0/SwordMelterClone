using UnityEngine;

public class knife : MonoBehaviour
{
    [Header("---movement settings---")]
    [SerializeField] private float forwartspeed;
    [SerializeField] private float borderx;
    [SerializeField] private float sensibility;
    [Header("---------------------")]
    private Touch touch;


    void Update()
    {
        transform.position += transform.up * forwartspeed * Time.deltaTime;
        input();
    }
    private void input()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float touchDeltaX = touch.deltaPosition.x * sensibility * Time.deltaTime;
                float endPosx = transform.position.x + touchDeltaX;
                endPosx = Mathf.Clamp(endPosx, -borderx, borderx);
                transform.position = new Vector3(endPosx, transform.position.y, transform.position.z);
            }
        }
    }
}
