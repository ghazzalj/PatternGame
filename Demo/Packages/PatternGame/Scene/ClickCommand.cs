using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Package.ExamplePackage
{
    public class ClickCommand : ICommand
    {
        private Renderer _renderer;
        private AudioClip _audio;


        public ClickCommand(AudioClip audio, Renderer renderer)
        {

            this._audio = audio;
            this._renderer = renderer;



        }
        public void Execute()
        {

            Manager.Repeat(_audio, _renderer);



        }





    }
}