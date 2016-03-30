using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    private bool _moving;
    public float timeBetweenMove;
    private float _timeBetweenMoveCounter;
    public float timeToMove;
    private float _timeToMoveCounter;
    public float waitToReload;
    private bool _reloading;
    private GameObject _thePlayer;

    private Rigidbody2D _myRigidbody;
    private Vector3 _moveDirection;

    // Use this for initialization
    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();

        //_timeBetweenMoveCounter = timeBetweenMove;
        //_timeToMoveCounter = timeToMove;

        _timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        _timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_moving)
        {
            _timeToMoveCounter -= Time.deltaTime;
            _myRigidbody.velocity = _moveDirection;

            if (_timeToMoveCounter < 0f)
            {
                _moving = false;
                //_timeBetweenMoveCounter = timeBetweenMove;
                _timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            _timeBetweenMoveCounter -= Time.deltaTime;
            _myRigidbody.velocity = Vector2.zero;

            if (_timeBetweenMoveCounter < 0f)
            {
                _moving = true;
                //_timeToMoveCounter = timeToMove;
                _timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                _moveDirection = new Vector3(Random.Range(-1, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if (_reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                _thePlayer.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.name == "Player")
        //{
        //    other.gameObject.SetActive(false);
        //    _reloading = true;
        //    _thePlayer = other.gameObject;
        //}
    }
}