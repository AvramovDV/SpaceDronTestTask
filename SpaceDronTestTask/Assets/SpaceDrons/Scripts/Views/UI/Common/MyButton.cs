using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Avramov.SpaceDrons
{
    public class MyButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PointerEventData> ClickEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            ClickEvent?.Invoke(eventData);
        }
    }
}
