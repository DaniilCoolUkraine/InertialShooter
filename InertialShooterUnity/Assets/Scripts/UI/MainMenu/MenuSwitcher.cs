using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI.MainMenu
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private Button _switchButton;
        [SerializeField] private GameObject _menuScreen;

        [SerializeField] private GameObject[] _otherMenus;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _switchButton.onClick.AddListener(SwitchScreen);
        }

        private void OnDisable()
        {
            _switchButton.onClick.RemoveListener(SwitchScreen);
        }

        private void SwitchScreen()
        {
            _menuScreen.SetActive(!_isOpened);

            foreach (GameObject menu in _otherMenus)
            {
                menu.SetActive(false);
            }
        }
    }
}