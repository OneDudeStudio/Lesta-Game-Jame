using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _cost = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wallet wallet))
        {
            wallet.AddMoney(_cost);
            //particles
            Destroy(gameObject);
        }
    }
}
