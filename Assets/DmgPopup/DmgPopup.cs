using UnityEngine;

namespace DmgPopup
{
    public class DmgPopup : MonoBehaviour
    {
        private Player.Player _player;
        private void Start()
        {
            _player = Player.Player.Instance;
            Destroy(gameObject, 1f);
        }
        void Update()
        {
            transform.LookAt(_player.transform.position);
            transform.Rotate(new Vector3(0, 180, 0));
            transform.Translate(new Vector3(Random.Range(-1f, 1f), Random.Range(0, 3f), Random.Range(-1f, 1f)) * Time.deltaTime);
        }
    }
}
