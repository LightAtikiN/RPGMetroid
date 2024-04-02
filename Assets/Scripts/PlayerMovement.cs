using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEditor;

class PlayerMovement : NetworkBehaviour
{
    [SerializeField] float speed;

    [SerializeField] int HP;
    [SerializeField] int maxHP;

    [SerializeField] int DMG;

    [SerializeField] float dashCD;
    [SerializeField] float maxDashCD;

    [SerializeField] float jumpForce;
    [SerializeField] int junpsCount;

    [SerializeField] Transform SpawnPoint;

    [SerializeField] KeyCode jumpKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode downKey;
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode attackKey;
    [SerializeField] KeyCode dashKey;

    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    private void Start()
    {
        if (!isLocalPlayer) return;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isLocalPlayer) return;
        if (dashCD >= 0)
        {
            dashCD -= Time.deltaTime;
        }
        if (HP <= 0)
        {
            transform.position = SpawnPoint.position;
        }
        if (Input.GetKeyDown(jumpKey) && Physics2D.Raycast(transform.position, -transform.up, 0.7f, groundLayer))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(jumpKey) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        Movement();
    }
    void Movement()
    {
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey(rightKey))
        {
            moveVector += Vector3.right;
        }
        if (Input.GetKey(leftKey))
        {
            moveVector += Vector3.left;
        }
        transform.position += moveVector.normalized * speed * Time.deltaTime;
    }
}
