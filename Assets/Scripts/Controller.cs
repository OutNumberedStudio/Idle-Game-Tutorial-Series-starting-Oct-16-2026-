using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Data data;
    
    public TMP_Text flaskstext;

    //Start() goes on starting the game
    private void Start()
    {
        data = new Data();
    }

    /// Displays the amount of flasks every fram
    private void Update()
    {
        flaskstext.text = data.flasks + " Flasks";
    }

    public void GeneratesFlasks()
    {
        //uses Data script to access variable flasks and then adds 1
        data.flasks += 1;
    }
}
