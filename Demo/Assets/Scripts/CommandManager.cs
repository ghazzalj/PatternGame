using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Package.ExamplePackage
{
    public class CommandManager : MonoBehaviour
    {
        //Singlton pattern for the command manager
        private static CommandManager _instance;
        private List<ICommand> _commandBuffer = new List<ICommand>();
        public static CommandManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<CommandManager>();


                return _instance;
            }


        }
        // Start is called before the first frame update
        void Awake()
        {
            _instance = this;
        }

        public void AddCommand(ICommand command)
        {

            _commandBuffer.Add(command);


        }
        public void Reset()
        {
            _commandBuffer.Clear();
        }
        public void Play()
        {

            StartCoroutine(PlayRoutine());


        }

        IEnumerator PlayRoutine()
        {

            foreach (var command in _commandBuffer)
            {

                command.Execute();
                yield return new WaitForSeconds(1.0f);
            }

        }


        public void Replay()
        {

            StartCoroutine(ReplayRoutine());

        }

        IEnumerator ReplayRoutine()
        {

            foreach (var command in Enumerable.Reverse(_commandBuffer))
            {

                command.Execute();
                yield return new WaitForSeconds(1.0f);
            }
            _commandBuffer.Clear(); // clear buffer after finishing
        }



    }
}