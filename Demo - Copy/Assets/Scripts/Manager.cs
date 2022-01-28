using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static event System.Action<AudioClip, Renderer> play; // creating an event to play an audio corresponding to obj and to change color when pressed
    [SerializeField]
    private AudioClip[] audios = new AudioClip[3];
    private Renderer renderers;
    private int index;

    private void Start()
    {
        renderers = gameObject.GetComponent<Renderer>();
        index = int.Parse(gameObject.name); // get index for audio

    }

    void OnMouseDown() {
    
        play.Invoke(audios[int.Parse(gameObject.name)], renderers); // inoke event when a cube is pressed
        ICommand click = new ClickCommand(audios[int.Parse(gameObject.name)], renderers); //creating a clicking command
        CommandManager.Instance.AddCommand(click);// add the command in the list


    }
   public static void Repeat(AudioClip audios, Renderer renderers) {

        play.Invoke(audios, renderers); // invoked when a command is executed 


    }


   

  

}
