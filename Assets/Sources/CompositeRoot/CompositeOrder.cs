using System.Collections.Generic;
using UnityEngine;

namespace Sources.CompositeRoot
{
    internal sealed class CompositeOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _compositeRoots;
        
        public void Awake()
        {
            foreach (var compositeRoot in _compositeRoots)
                compositeRoot.Compose();
        }
    }
}