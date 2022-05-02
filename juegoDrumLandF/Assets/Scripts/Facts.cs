using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Rodrigo Alfredo Mendoza España
// Asignar al texto en loading un texto aleatorio de facts
public class Facts : MonoBehaviour
{
    public TextMeshProUGUI facts;


    string[] arrayFacts = { "Percussion instruments are consider the oldest musical instruments",
    "Some percussion instruments are tuned and can sound different notes, like the xylophone, timpani or piano",
    "Some percussion instruments are untuned with no definite pitch, like the bass drum, cymbals or castanets.",
    "The term percussion comes from the Latin word, percussionem, which means “a striking, a blow.",
    "Percussion instruments fall into one of two categories, idiophones and membranophones, and create sound by striking, shaking, rubbing, plucking, or scraping.",
    "Percussion is the oldest group of instruments with over a hundred types with origins from all across the world.",
    "The human body is considered a percussion instrument."};

    private void Start()
    {
        int index = Random.Range(0, arrayFacts.Length);
        facts.text = arrayFacts[index];
    }

}
