using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Package.ExamplePackage
{
    public class Button : MonoBehaviour
    {
        public void Submit()
        {

            CommandManager.Instance.Play();

        }

        public void Replay()
        {

            CommandManager.Instance.Replay();

        }

        public void Reset()
        {

            CommandManager.Instance.Reset();

        }
    }
}