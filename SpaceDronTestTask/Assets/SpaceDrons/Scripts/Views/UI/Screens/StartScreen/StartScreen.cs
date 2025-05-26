using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class StartScreen : BaseScreen
    {
        [field: SerializeField] public MyButton StartButton { get; private set; }
        [field: SerializeField] public MyButton ExitButton { get; private set; }
    }
}
