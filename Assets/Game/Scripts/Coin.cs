using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField]
    private AudioClip _pickupClip;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
            Player player = other.GetComponent<Player>();
            if (player != null) {
                player.hasCoin = true;
                AudioSource.PlayClipAtPoint(_pickupClip, this.transform.position, 0.3f);
                UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                if (uiManager != null)
                    uiManager.UpdateCoin();
                Destroy(this.gameObject);
            }
        }
    }
}
