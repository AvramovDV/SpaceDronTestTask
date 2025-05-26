using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class ResourceSpawner : MonoBehaviour
    {
        [SerializeField] private ResourceView _prefab;
        [SerializeField] private Transform _spawnField;

        private List<ResourceView> _resList = new List<ResourceView>();

        public IReadOnlyList<ResourceView> Resources => _resList;

        public event Action SpawnEvent;

        public void SpawnResource(ResourceModel model)
        {
            ResourceView view = Instantiate(_prefab, GetSpawnPosition(), Quaternion.identity, transform);
            view.Setup(model);
            _resList.Add(view);
            SpawnEvent?.Invoke();
        }

        public void DestroyResource(ResourceModel model)
        {
            var view = _resList.Find(x => x.Model == model);
            DestroyResource(view);
        }

        public void GetView(ResourceModel model) => _resList.Find(x => x.Model == model);

        public void Claer()
        {
            foreach (var view in _resList) 
                Destroy(view.gameObject);

            _resList.Clear();
        }

        private void DestroyResource(ResourceView view)
        {
            if (view != null)
            {
                view.Setup(null);
                _resList.Remove(view);
                Destroy(view.gameObject);
            }
        }

        private Vector3 GetSpawnPosition()
        {
            Vector3 pos = new Vector3();
            pos.x = UnityEngine.Random.Range(-0.5f, 0.5f);
            pos.y = UnityEngine.Random.Range(-0.5f, 0.5f);
            pos.z = 0f;
            return _spawnField.TransformPoint(pos);
        }
    }
}
