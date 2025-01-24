Shader "Custom/XRayUnlitShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,0,0.5)
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
        LOD 100

        Pass
        {
            Lighting Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            float4 _Color;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
