using System.Collections;
using UnityEngine;

namespace WhereIsMyControl.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}