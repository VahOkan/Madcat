using UnityEngine;

namespace DmgPopup
{
    public class DmgPopup : MonoBehaviour
    {
        private Player.PlayerHP _playerHp;
        private void Start()
        {
            _playerHp = Player.PlayerHP.Instance;
            Destroy(gameObject, 1f);
        }
        void Update()
        {
            transform.LookAt(_playerHp.transform.position);
            transform.Rotate(new Vector3(0, 180, 0));
            transform.Translate(new Vector3(Random.Range(-1f, 1f), Random.Range(0, 3f), Random.Range(-1f, 1f)) * Time.deltaTime);
        }
    }
}
