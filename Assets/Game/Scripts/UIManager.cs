using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private GameObject _coin;

    private void Start() {
        _ammoText.text = "Buy a weapon!";
    }

    public void UpdateAmmo(int count) {
        _ammoText.text = "Ammo: " + count;
    }

    public void UpdateCoin() {
        _coin.SetActive(!_coin.activeSelf);
    }
}
