using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Director : MonoBehaviour
{
    public PlayableDirector timeline;
    public PlayableDirector cutscene2;
    public static Director diretor;
    private void Awake()
    {
        diretor = this;
        timeline = GetComponent<PlayableDirector>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // A tecla de espaço foi pressionada, pule a Timeline.
            if (timeline != null)
            {
                timeline.time = timeline.duration;
            }
        }
    }
    private void PLayCutscene()
    {
        cutscene2.Play();
    }
}
