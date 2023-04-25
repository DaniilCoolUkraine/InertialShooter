using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI.Screens
{
    public class LooseScreenController : ScreenController
    {
        [SerializeField] private Image _overlay;
        
        public override void EnableScreen()
        {
            base.EnableScreen();

            _overlay.DOFade(.5f, 1);
        }
    }
}