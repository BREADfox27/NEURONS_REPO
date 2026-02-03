using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    [SerializeField] int sfxToPlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlaySFX(sfxToPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
