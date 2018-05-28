// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePNG : MonoBehaviour {

    private int _Counter;
    private float _Timer;
    private float _TimerTransition;
    private float _Clamp;
    private bool _ClampFlip;

    private Renderer _ScreenRenderer;
    private Color _ScreenTintColor;

    public float TransitionTime;
    public List<Texture> ScreenTextures = new List<Texture>();
    public List<float> ScreenTexturesTime = new List<float>();

    // Use this for initialization
    void Start()
    {
        _ScreenRenderer = GetComponent<Renderer>();
        _ScreenRenderer.material.SetTexture("_MainTex", ScreenTextures[0]);
        _Counter = 0;
        _ScreenTintColor = _ScreenRenderer.material.GetColor("_Color");
        _ScreenTintColor.a = 1.0f;
        _Clamp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenStates();
    }

    private void ScreenStates()
    {
        _Timer += Time.deltaTime;
        if (_Counter <= (ScreenTextures.Count - 1))
        {

            if (_Timer < ScreenTexturesTime[_Counter])
            {
                if ((_Clamp >= 1.0) && !_ClampFlip)
                {
                    _ClampFlip = true;
                    _TimerTransition = ScreenTexturesTime[_Counter] - TransitionTime;

                }

                if (!_ClampFlip)
                {
                    _TimerTransition += Time.deltaTime;
                    _Clamp = Mathf.Clamp01(_TimerTransition);
                    if (_TimerTransition < TransitionTime)
                    {
                        _ScreenTintColor.a = _Clamp;
                    }
                }
                else if (_ClampFlip)
                {
                    _TimerTransition -= Time.deltaTime;
                    _Clamp = Mathf.Clamp01(_TimerTransition);
                    if (_TimerTransition > 0.0f)
                    {
                        _ScreenTintColor.a = _Clamp;
                    }
                    else
                    {
                        _ScreenTintColor.a = 0.0f;
                    }
                }
                _ScreenRenderer.material.SetTexture("_MainTex", ScreenTextures[_Counter]);
                _ScreenRenderer.material.SetColor("_Color", _ScreenTintColor);
            }
            else
            {
                _Timer = 0;
                _TimerTransition = 0;
                _Clamp = 0;
                _ClampFlip = false;
                _Counter += 1;
            }
        }
    }

    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
