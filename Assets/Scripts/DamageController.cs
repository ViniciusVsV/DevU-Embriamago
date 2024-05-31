using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DamageController : MonoBehaviour{
    public float intensity = 0;
    private float elapsedTime = 0f;

    PostProcessVolume volume;
    Vignette vignette;

    void Start(){
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings<Vignette>(out vignette);

        vignette.enabled.Override(false);
    }

    public IEnumerator TakeDamageEffect(float waitTime){
        elapsedTime = 0f;
        intensity = 0.4f;

        vignette.enabled.Override(true);
        vignette.intensity.Override(0.5f);

        yield return new WaitForSeconds(waitTime);

        while(elapsedTime < 1f){
            elapsedTime += Time.deltaTime;

            float currentIntensity = Mathf.Lerp(0.5f, 0f, elapsedTime / 1f);
            vignette.intensity.Override(currentIntensity);

            yield return null;
        }

        vignette.enabled.Override(false);
    }
}
