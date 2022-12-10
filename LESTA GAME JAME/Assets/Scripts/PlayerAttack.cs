using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private AttackCollider _attackCollider;
    public void Attack()
    {
        //anim
        _attackCollider.TryAttack();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
}
