using UnityEngine;

public class MovementScene : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 5f;

    private void Start()
    {
        //startPoint = Vector3(23, 17, 37);
        //endPoint = Vector3(4, 9, 4);
        if (startPoint != null)
        {
            transform.position = startPoint.position;
        }
    }

    private void Update()
    {
        if (endPoint == null)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            endPoint.position,
            speed * Time.deltaTime
        );
    }
}