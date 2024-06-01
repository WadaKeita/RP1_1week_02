using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRange : MonoBehaviour
{
    // ˆÚ“®”ÍˆÍ‚ÌÅ‘å”¼Œa
    [SerializeField] private float _maxRadius = 1;

    public static GameObject movementRange;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(_maxRadius * 2, _maxRadius * 2, 0);
    }

    public Vector3 ClampCircle(Vector3 position)
    {
        Vector3 pos = position;

        // w’è‚³‚ê‚½”¼Œa‚Ì‰~“à‚ÉˆÊ’u‚ğŠÛ‚ß‚é
        var clampedPos = Vector2.ClampMagnitude(pos, _maxRadius);

        return new Vector3(clampedPos.x, clampedPos.y, pos.z);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
