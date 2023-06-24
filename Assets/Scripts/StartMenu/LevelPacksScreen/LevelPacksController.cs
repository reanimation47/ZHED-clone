using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu.LevelPacksScreen
{
    public class LevelPacksController : MonoBehaviour
    {
        public GameObject Prefab_PackSelectButton;

        private BaseConfiguration configuration = new BaseConfiguration();
        public int PacksCount = 0;
        // Start is called before the first frame update
        void Awake()
        {
            PacksCount = configuration.PacksCount;
        }

        void Start()
        {
            CreatePacksButton();
        }

        private void CreatePacksButton()
        {
            for (int i = 1; i <= PacksCount; i++)
            {
                GameObject _pack = Instantiate(Prefab_PackSelectButton, gameObject.transform);
                _pack.GetComponent<Buttons.PackSelectButton>().PackInit(i);
            }
        }
    }
}

