//=======================================================================
// Ben Resnick, 2017
//=======================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmfLite;

//TODO make this a generic class or interface, support multiple songs
public class LivingSongKimbra : LivingSongController {


  public void createSquibble(MidiEvent e) {
    float normalizedNoteChange = (((float) e.data1) - 60);
     // Debug.Log(normalizedNoteChange);


    //Vector3 pos = new Vector3(normalizedNoteChange,normalizedNoteChange,1);
    Vector3 pos = generateCirclePosition(normalizedNoteChange);
    lsControl.queueNextSquibble (new SquibbleData (pos));

  }

}
