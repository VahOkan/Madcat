using UnityEngine;

public class DmgPopup : MonoBehaviour
{
    private PlayerHP _playerHp;
    Vector3 moveDirection;
    private void Start()
    {
        _playerHp = PlayerHP.Instance;
        Destroy(gameObject, 1f);
        moveDirection = new Vector3(Random.Range(-1f, 1f), 2, Random.Range(-1f, 1f));
    }
    void Update()
    {
        transform.LookAt(_playerHp.transform.position);
        transform.Rotate(new Vector3(0, 180, 0));
        transform.Translate(moveDirection * Time.deltaTime);
    }
}
