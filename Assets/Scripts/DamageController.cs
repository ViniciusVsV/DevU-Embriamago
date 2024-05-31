using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageController : MonoBehaviour{
    public float baseIntensity = 0.2f;
    public float damageIntensity = 0.5f; 
    public float fadeDuration = 1f; 
    private float elapsedTime = 0f;

     PostProcessVolume volume;
    Vignette vignette;

    void Start(){
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings<Vignette>(out vignette);

        vignette.enabled.Override(true);
        vignette.intensity.Override(baseIntensity);
    }

    public IEnumerator TakeDamageEffect(float waitTime){
        elapsedTime = 0f;

        // Intensify the vignette effect
        vignette.intensity.Override(damageIntensity);

        yield return new WaitForSeconds(waitTime);

        // Fade back to the base intensity
        while (elapsedTime < fadeDuration){
            elapsedTime += Time.deltaTime;

            float currentIntensity = Mathf.Lerp(damageIntensity, baseIntensity, elapsedTime / fadeDuration);
            vignette.intensity.Override(currentIntensity);

            yield return null;
        }
    }
}