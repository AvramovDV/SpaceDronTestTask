using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class ScreensManager : MonoBehaviour
    {
        [SerializeField] private List<BaseScreen> _screens;
        [SerializeField] private RectTransform _screensContent;

        private Dictionary<Type, BaseScreen> _screensDict = new Dictionary<Type, BaseScreen>();

        public T GetScreen<T>() where T : BaseScreen
        {
            if (!_screensDict.ContainsKey(typeof(T)))
                AddScreen<T>();

            return (T)_screensDict[typeof(T)];
        }

        private void AddScreen<T>()
        {
            BaseScreen prefab = _screens.Find(x => x is T);
            BaseScreen screen = Instantiate(prefab, _screensContent);
            _screensDict.Add(typeof(T), screen);
        }
    }
}
