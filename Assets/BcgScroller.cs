using UnityEngine;

public class BcgScroller : MonoBehaviour
{
    private Material mat;

    private float horizontal;
    private float vertical;
    [Range(0f,10f)]
    public float speed = 5f;
    private float dX;
    private float dY;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        dX += (Time.deltaTime * horizontal * speed) / 10f;
        dY += (Time.deltaTime * vertical * speed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(dX, dY));
    }
}
