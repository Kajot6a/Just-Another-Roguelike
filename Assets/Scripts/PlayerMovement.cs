using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private float horizontal;
    private float vertical;
    private float speed = 8f;

    [SerializeField] private Renderer pl;
    // [SerializeField] private RigidBody2D rb;
    

    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        // mat = pl;
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        float dX = (Time.deltaTime * horizontal * speed) / 10f;
        float dY = (Time.deltaTime * vertical * speed) / 10f;
        // offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(dX, dY));

    }
}
