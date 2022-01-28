using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request : MonoBehaviour
{
    private Queue<Renderer> rq = new Queue<Renderer>();
    private Queue<AudioClip> aq = new Queue<AudioClip>();
    [SerializeField]
    private AudioSource audioSource;


    void OnEnable() {
        //subscirbe 
        Manager.play += Manager_play;
    
    }

    void OnDisable() {
        //Unsubscribe
        Manager.play -= Manager_play;
 
    }

    private void Manager_play(AudioClip a, Renderer r)
    {
        //add requested audio clip to the queue
        aq.Enqueue(a);
        rq.Enqueue(r);
    }

    // Update is called once per frame
    void Update() {
        
        CheckQueue();
          
    }


    void CheckQueue() {

        if ((rq.Count>0)&&(aq.Count > 0) && (audioSource.isPlaying == false)) {
            Playaudio(aq.Dequeue(), rq.Dequeue());


        }

    }
    void Playaudio(AudioClip a, Renderer r) {
        audioSource.clip = a;
        audioSource.Play();
        StartCoroutine(GoBlue(r));
    }


    IEnumerator GoBlue(Renderer r)
    {
       
            r.GetComponent<Renderer>().material.color = Color.magenta;
            yield return new WaitForSeconds(1);
            r.GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(1);



    }

  

}
