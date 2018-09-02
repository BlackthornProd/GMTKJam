using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour {

    private PlayerSelect playerSelect;

    private void Start()
    {
        playerSelect = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerSelect>();
        playerSelect.enemiesInGame++;
    }

    public void Remove() {
        playerSelect.enemiesInGame--;
    }
}
