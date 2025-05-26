using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Avramov.SpaceDrons
{
    public class GameSettingsScreen : BaseScreen
    {
        [field: SerializeField] public Slider DronsCountSlider { get; private set; }
        [field: SerializeField] public TMP_Text DronsCountText { get; private set; }
        [field: SerializeField] public Slider DronsSpeedSlider { get; private set; }
        [field: SerializeField] public TMP_Text DronsSpeedText { get; private set; }
        [field: SerializeField] public TMP_InputField ResourceGenerationRateInputField { get; private set; }
        [field: SerializeField] public TMP_InputField MaxResourceCountInputField { get; private set; }
        [field: SerializeField] public Toggle DronsPathToggle { get; private set; }
        [field: SerializeField] public MyButton ExitButton { get; private set; }
    }
}
