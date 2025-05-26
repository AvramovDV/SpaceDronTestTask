namespace Avramov.SpaceDrons
{
    public class MatchSettingsModel
    {
        public CustomProperty<int> DronsCount { get; private set; } = new CustomProperty<int>();
        public CustomProperty<int> DronsSpeed { get; private set; } = new CustomProperty<int>();
        public CustomProperty<float> ResourcesSpawnRate { get; private set; } = new CustomProperty<float>();
        public CustomProperty<int> ResourcesMaxCount { get; private set; } = new CustomProperty<int>();
        public CustomProperty<bool> ShowDronsPaths { get; private set; } = new CustomProperty<bool>();

        public void Setup(MatchSettingsData data)
        {
            DronsCount.Value = data.DronsCount;
            DronsSpeed.Value = data.DronsSpeed;
            ResourcesSpawnRate.Value = data.ResourcesSpawnRate;
            ResourcesMaxCount.Value = data.ResourcesCount;
            ShowDronsPaths.Value = data.ShowDronsPaths;
        }

        public MatchSettingsData GetData()
        {
            return new MatchSettingsData()
            {
                DronsCount = DronsCount.Value,
                DronsSpeed = DronsSpeed.Value,
                ResourcesSpawnRate = ResourcesSpawnRate.Value,
                ResourcesCount = ResourcesMaxCount.Value,
                ShowDronsPaths = ShowDronsPaths.Value,
            };
        }
    }
}
