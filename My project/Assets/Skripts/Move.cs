using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform Texture;
    [SerializeField] private Transform feetposition;
    [SerializeField] private float jumpforce = 6.5f;
    [SerializeField] private float grounddistance = 0.25f;
    [SerializeField] private float Jumptime = 0.3f;
    [SerializeField] private float CrouchHeight = 0.5f;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumptimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetposition.position, grounddistance, layerMask);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumptimer = 0;
        }


        if (isGrounded && Input.GetButtonDown("Crounch"))
        {
            Texture.localScale = new Vector3(Texture.localScale.x, CrouchHeight, Texture.localScale.z);
        }
        if (isJumping && Input.GetButton("Crounch"))
        {
            Texture.localScale = new Vector3(Texture.localScale.x, 1f, Texture.localScale.z);
        }
        if (Input.GetButtonUp("Crounch"))
        {
            Texture.localScale = new Vector3(Texture.localScale.x, 1f, Texture.localScale.z);
        }
    }
}
