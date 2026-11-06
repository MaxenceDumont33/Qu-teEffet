using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Movement ownerMovement;
    Jump ownerJump;
    public int hp = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0)
            Debug.Log("Dead");
    }
    public void SetSpeedModifier(float speedModifier)
    {
        ownerMovement.speedModifier += speedModifier;
    }

    public void SetJumpModifier(float jumpModifier)
    {
        ownerJump.jumpModifier += jumpModifier;
    }
}
