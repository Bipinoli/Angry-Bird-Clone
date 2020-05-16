using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector2 _initialPosition;
    private float _timeSittingAround;
    private bool _birdWasLaunched;

    [SerializeField] private float _flyForce = 400;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -7.5f ||
            transform.position.y > 7.5f ||
            transform.position.x < -15f ||
            transform.position.x > 15f ||
            _timeSittingAround > 3)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }

        if (GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1 && _birdWasLaunched)
        {
            _timeSittingAround += Time.deltaTime;
        }

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition    );

    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().AddForce((_initialPosition - new Vector2(transform.position.x, transform.position.y)) * _flyForce);
        _birdWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
