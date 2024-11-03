using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace SmallBiz.UIDoc
{
    public class DocBase : MonoBehaviour
    {
        protected VisualElement _rootElement;

        protected virtual void Start()
        {
            var uiDocument = GetComponent<UIDocument>();
            if (uiDocument != null)
            {
                _rootElement = uiDocument.rootVisualElement;
            }
            else
            {
                throw new MissingComponentException("UIDocument component not found on " + gameObject.name);
            }
        }

        public VisualElement GetElement<T>(string elementName) where T : VisualElement
        {
            if (_rootElement == null)
                return _rootElement.Q<T>(elementName);
            else
                throw new Exception($"Element '{elementName}' not found in the UI document.");
        }

        public void Open()
        {
            if (_rootElement != null)
            {
                _rootElement.style.display = DisplayStyle.Flex;
            }
            else
            {
                throw new InvalidOperationException("Root element is not initialized.");
            }
        }

        public void Close()
        {
            if (_rootElement != null)
            {
                _rootElement.style.display = DisplayStyle.None;
            }
            else
            {
                throw new InvalidOperationException("Root element is not initialized.");
            }
        }
    }
}