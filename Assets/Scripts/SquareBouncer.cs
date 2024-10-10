using UnityEngine;

public class SquareBouncer : MonoBehaviour
{
    public float frequency = 1.0f;
    public float amplitude = 1.0f;

    private float startY = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var yOffset = Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad * frequency) * amplitude);
        var pos = transform.position;

        pos.y = startY + yOffset;

        transform.position = pos;
    }
}
