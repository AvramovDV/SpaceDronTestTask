using System;

namespace Avramov.SpaceDrons
{
    [Serializable]
    public struct MatchSettingsData
    {
        public int DronsCount;
        public int DronsSpeed;
        public float ResourcesSpawnRate;
        public int ResourcesCount;
        public bool ShowDronsPaths;
    }
}
