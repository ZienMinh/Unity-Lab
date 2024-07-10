using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Thêm thư viện này để sử dụng UI

public class PlayerController : MonoBehaviour
{
    bool canMove = true;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] Text scoreText; // Thêm biến để tham chiếu đến Text UI cho điểm số
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    float currentRotation = 0f; // Biến để theo dõi góc quay hiện tại
    int score = 0; // Biến để theo dõi điểm số

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        UpdateScoreText(); // Cập nhật điểm số ban đầu
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
            CheckRotation();
        }
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    private void CheckRotation()
    {
        currentRotation += Mathf.Abs(rb2d.angularVelocity) * Time.deltaTime;
        if (currentRotation >= 360f)
        {
            currentRotation -= 360f; // Đặt lại góc quay
            IncreaseScore(); // Tăng điểm
        }
    }

    private void IncreaseScore()
    {
        score += 1;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}