using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Movement ownerMovement;
    public Jump ownerJump;
    public int hp = 0;
    public float speed = 0;
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
        Debug.Log("damage");
        if (hp < 0)
            Debug.Log("Dead");
    }
    public void SetSpeedModifier(float speedModifier)
    {
        ownerMovement.speedModifier += speedModifier;
        speed -= speedModifier; 
    }

    public void SetJumpModifier(float jumpModifier)
    {
        ownerJump.jumpModifier += jumpModifier;
    }
}
