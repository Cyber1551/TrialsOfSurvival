using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameAssets : MonoBehaviour
    {

        public static GameAssets I;
        public Transform damagePopupPrefab;
        public PlayerController player;
        private void Awake()
        {
            I = this;

        }
    }
