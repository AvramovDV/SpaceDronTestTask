using System.Collections.Generic;
using System.Linq;

namespace Avramov.SpaceDrons
{
    public class DronsSystem : BaseSystem
    {
        private MatchSettingsModel _matchSettingsModel;
        private MatchModel _matchModel;
        private DIFactory _factory;

        private List<DronLogic> _logicList = new List<DronLogic>();

        public DronsSystem(
            MatchSettingsModel matchSettingsModel,
            MatchModel matchModel,
            DIFactory factory)
        {
            _matchSettingsModel = matchSettingsModel;
            _matchModel = matchModel;
            _factory = factory;
        }

        protected override void Activated()
        {
            _matchSettingsModel.DronsCount.ChangedEvent += UpdateDronsCount;

            UpdateDronsCount();
        }

        protected override void Deactivated()
        {
            _matchSettingsModel.DronsCount.ChangedEvent -= UpdateDronsCount;
            Clear();
        }

        private void UpdateDronsCount()
        {
            UpdateDronsCountForFraction(0);
            UpdateDronsCountForFraction(1);
        }

        private void UpdateDronsCountForFraction(int fractionId)
        {
            var drons = _matchModel.Drons.Where(x => x.FractionId == fractionId);
            int count = drons.Count();
            if (count == _matchSettingsModel.DronsCount.Value)
                return;

            if(count < _matchSettingsModel.DronsCount.Value)
            {
                int c = _matchSettingsModel.DronsCount.Value - count;
                AddDronsToFraction(fractionId, c);
            }
            else  if (count > _matchSettingsModel.DronsCount.Value)
            {
                int c = count - _matchSettingsModel.DronsCount.Value; 
                RemoveDronsFromFraction(fractionId, c);
            }
        }

        private void AddDronsToFraction(int fractionId, int count)
        {
            for (int i = 0; i < count; i++)
            {
                DronLogic logic = _factory.Get<DronLogic>();
                logic.Init(fractionId);
                _logicList.Add(logic);
            }
        }

        private void RemoveDronsFromFraction(int fractionId, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var logic = _logicList.Find(x => x.FractionId == fractionId);
                logic.Dispose();
                _logicList.Remove(logic);
            }
        }

        private void Clear()
        {
            foreach (var logic in _logicList)
                logic.Dispose();

            _logicList.Clear();
        }
    }
}
