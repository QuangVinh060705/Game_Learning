using UnityEngine;
using UnityEngine.Events;
using System;

public class HealthSystem : MonoBehaviour
{
    [Header("Settings")]
    public int maxHealth = 5;
    private int currentHealth;
    public bool isPlayer = false;

    [Header("Lab 6: Unity Events")]
    public UnityEvent OnDeath; 
    public UnityEvent OnDamageTaken;

    public static event Action<int> OnPlayerHealthChanged; 

    // MỚI: Biến để lấy cái ảnh (Sprite) của vật thể
    private SpriteRenderer mySprite;

    void Start()
    {
        currentHealth = maxHealth;
        
        // MỚI: Tự động tìm SpriteRenderer gắn trên object này
        mySprite = GetComponent<SpriteRenderer>();

        if (isPlayer) NotifyUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // MỚI: Gọi hàm đổi màu ngay khi mất máu
        UpdateColor();

        OnDamageTaken?.Invoke();

        if (isPlayer) NotifyUI();

        if (currentHealth <= 0) Die();
    }

    // MỚI: Hàm xử lý đổi màu
    void UpdateColor()
    {
        // Nếu object này có hình ảnh (Sprite) và không phải Player (tùy chọn)
        if (mySprite != null)
        {
            // Tính phần trăm máu còn lại (Phải ép kiểu float để ra số lẻ)
            float healthPercent = (float)currentHealth / maxHealth;

            // Color.Lerp sẽ pha màu từ Đen (0) đến Trắng (1) dựa theo %
            // Máu càng ít, màu càng gần màu Đen
            mySprite.color = Color.Lerp(Color.black, Color.white, healthPercent);
        }
    }

    void NotifyUI()
    {
        OnPlayerHealthChanged?.Invoke(currentHealth);
    }

    void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}