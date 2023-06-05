using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem.Sample
{
[RequireComponent( typeof( Interactable ) )]
public class NoteAppear : MonoBehaviour
{
    [SerializeField]
    private Image _noteImage;

    private Interactable interactable;

    void Awake()
    {
        interactable = this.GetComponent<Interactable>();
    }

    private void OnAttachedToHand( Hand hand )
    {
        _noteImage.enabled = true;
    }

    private void OnDetachedFromHand( Hand hand )
    {
        _noteImage.enabled = false;
    }
}
}