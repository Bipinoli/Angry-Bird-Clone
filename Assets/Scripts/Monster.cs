using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameObject _particleEffectWhenDie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        bool hitFromTop = collision.contacts[0].normal.y < 0.5f;
        if (bird != null || hitFromTop)
        {
            Instantiate(_particleEffectWhenDie, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
