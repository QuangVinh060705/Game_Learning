using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class PlayerHealthUE : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public IntEvent onHealthChanged;
    public UnityEvent onPlayerDied;

    void Start()
{
    currentHealth = maxHealth;
    onHealthChanged.Invoke(currentHealth); // BẮT BUỘC
}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
{
    currentHealth -= damage;
    currentHealth = Mathf.Max(0, currentHealth);

    onHealthChanged.Invoke(currentHealth); // BẮT BUỘC

    if (currentHealth <= 0)
        onPlayerDied.Invoke();
}

    

}
