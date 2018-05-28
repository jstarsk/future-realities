// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureRealities
{
    public class _GazeButton : GazeButton
    {
        public Renderer buttonRenderer;
        public Texture2D normalBgTexture;
        public Texture2D gazingBgTexture;

        private int shaderFillId;
        private int shaderBgId;

        private float oldGazeTime = 0f;

        void Awake()
        {
            shaderFillId = Shader.PropertyToID("_Fill");
            shaderBgId = Shader.PropertyToID("_MainTex");

            SetNormalTexture();
        }

        protected void Update()
        {
            base.Update();

            if (normalizedGazeTime != oldGazeTime)
            {
                MaterialPropertyBlock block = new MaterialPropertyBlock();
                buttonRenderer.GetPropertyBlock(block);
                block.SetFloat(shaderFillId, normalizedGazeTime);
                buttonRenderer.SetPropertyBlock(block);

                oldGazeTime = normalizedGazeTime;
            }
        }

        void OnButtonGaze()
        {
            Debug.Log("<color=red><size=20>Button was gazing!!</size></color>");

            SetNormalTexture();
        }

        void OnGazeBegin()
        {
            base.OnGazeBegin();

            SetGazingTexture();
        }

        void OnGazeEnd()
        {
            base.OnGazeEnd();

            SetNormalTexture();
        }

        void SetNormalTexture()
        {
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            buttonRenderer.GetPropertyBlock(block);
            block.SetTexture(shaderBgId, normalBgTexture);
            buttonRenderer.SetPropertyBlock(block);
        }

        void SetGazingTexture()
        {
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            buttonRenderer.GetPropertyBlock(block);
            block.SetTexture(shaderBgId, gazingBgTexture);
            buttonRenderer.SetPropertyBlock(block);
        }
    }
}