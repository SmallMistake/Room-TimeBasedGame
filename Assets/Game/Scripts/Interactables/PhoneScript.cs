using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PhoneScript : MonoBehaviour, I_Interactable
{
    private bool ringing = false;
    Animator animator;
    private EventInstance ringingSound;

    private void Start()
    {
        ringingSound = RuntimeManager.CreateInstance("event:/SFX/PhoneRinging");
        animator = GetComponent<Animator>();
    }

    public void InteractedWith(PlayerInventory playerInventory)
    {
        //TODO change this to only pickup phone if ringing
        setRingingState(!ringing);
    }

    public void setRingingState(bool ringing)
    {
        this.ringing = ringing;
        animator.SetBool("ringing", this.ringing);

        if(ringing == true)
        {
            ringingSound.start();
        }
        else
        {
            ringingSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
