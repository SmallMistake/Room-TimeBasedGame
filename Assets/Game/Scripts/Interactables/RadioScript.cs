using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour, I_Interactable
{
    private EventInstance radioChannel;
    private int channelID = 0;
    private int maxChannelNumber = 2;

    private void Start()
    {
        radioChannel = FMODUnity.RuntimeManager.CreateInstance("event:/Radio");
        radioChannel.start();
    }

    public void InteractedWith(PlayerInventory playerInventory)
    {
        ChangeChannel();
    }

    private void ChangeChannel()
    {
        channelID++;
        if (channelID > maxChannelNumber)
        {
            channelID = 0;
        }
        FMODUnity.RuntimeManager.CreateInstance("event:/SFX/RadioStatic").start();
        radioChannel.setParameterByName("Channel", channelID);
    }

    private void OnDestroy()
    {
        //This might be what destroys the FMOD Sound
        radioChannel.release();
    }
}
