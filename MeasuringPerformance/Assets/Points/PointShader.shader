Shader "Graph/Point Surface"{
    Properties{
        _Smoothness ("Smoothness", Range(0,1)) = .5
    }
    SubShader{
        CGPROGRAM
        #pragma surface ConfigureSurface Standard fullforwardshadows
        #pragma target 3.0

        struct Input{
            float3 worldPos;
        };

        float _Smoothness;

        void ConfigureSurface(Input input, inout SurfaceOutputStandard surface) {
        surface.Albedo = input.worldPos * .5 * .5;
        surface.Smoothness = _Smoothness;
        }
        ENDCG
    }

    Fallback "Diffuse"

}