using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {
    [SerializeField]
    private GameObject _weaponSold;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            if (Input.GetKey(KeyCode.E)) {
                Player player = other.GetComponent<Player>();
                if (player != null) {
                    if (player.hasCoin) {
                        Destroy(_weaponSold);
                        player.hasCoin = false;
                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if (uiManager != null)
                            uiManager.UpdateCoin();

                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapon();
                    }
                    else
                        Debug.Log("No money, no guns, bitch.");
                }
            }
            
            
        }
    }
}
