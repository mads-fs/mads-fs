using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MirrorYou
{
    public class EndScript : MonoBehaviour
    {
        public Image Overlay;
        public TMP_Text EndText;
        public TMP_Text NameCredits;
        public TMP_Text AssetCredits;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Play()
        {
            StartCoroutine(DoDelayedAction(() => StartCoroutine(DoFade(Overlay, 0.75f, 0.4f)), 0f));
            StartCoroutine(DoDelayedAction(() => StartCoroutine(DoFade(EndText, 1f, 1f)), 1f));
            StartCoroutine(DoDelayedAction(() => StartCoroutine(DoFade(NameCredits, 1f, 0.5f)), 3f));
            StartCoroutine(DoDelayedAction(() => StartCoroutine(DoFade(AssetCredits, 1f, 0.5f)), 3.5f));
        }

        public IEnumerator DoDelayedAction(Action action, float waitForSeconds)
        {
            yield return new WaitForSeconds(waitForSeconds);
            action?.Invoke();
        }

        public IEnumerator DoFade(Graphic graphic, float colorAlpha, float fadeTime)
        {
            Color start = graphic.color;
            Color end = new(graphic.color.r, graphic.color.g, graphic.color.b, colorAlpha);
            float timer = 0f;
            while(timer  < fadeTime)
            {
                timer += Time.deltaTime;
                float alpha = timer / fadeTime;
                graphic.color = Color.Lerp(start, end, alpha);
                yield return null;
            }
            graphic.color = end;
            yield return null;
        }
    }
}