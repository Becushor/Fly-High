using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird instance = null;

    private Rigidbody2D rigid;
    private Animator animator;
    public event EventHandler OnDied;

    private int score = 0;

    private static float jumpForce = 3f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -5.25f, 10000f));
        //this don't let the bird fall out of the screen
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rigid.velocity = Vector2.up * jumpForce;
            PlayJumpAnim(true);
            StartCoroutine(ResetJump());
        }
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.1f);
        PlayJumpAnim(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigid.bodyType = RigidbodyType2D.Static;
    }

    private void PlayJumpAnim(bool isJumping)
    {
        animator.SetBool("isJumping", isJumping);
    }

    public void CountScore()
    {
        if (rigid.velocity.y > 0 && transform.position.y > score)
        {
            score = (int)transform.position.y;
        }
    }

    public int ShowScore()
    {
        return score;
    }
}
