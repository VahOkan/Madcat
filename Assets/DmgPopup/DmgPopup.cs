using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPopup : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = Player.Instance;
        Destroy(gameObject, 1f);
    }
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Rotate(new Vector3(0, 180, 0));
        transform.Translate(new Vector3(Random.Range(-1f, 1f), Random.Range(0, 3f), Random.Range(-1f, 1f)) * Time.deltaTime);
    }
}
