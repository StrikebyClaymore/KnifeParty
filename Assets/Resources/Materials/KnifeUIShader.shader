Shader "Hidden/KnifeUIShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("ColorTint", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" 
                "Queue" = "Transparent" 
            }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
                
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Pixels;
            float4 _Ratio;
            float4 _Color;

            v2f vert (appdata v)
            {
                 v2f o;
                 o.vertex = UnityObjectToClipPos(v.vertex);
                 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                 UNITY_TRANSFER_FOG(o,o.vertex);
                 return o;
            }
            
            fixed4 sample_sprite_texture(float2 uv)
            {
                fixed4 color = tex2D(_MainTex, uv);

                #if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
                if (_AlphaSplitEnabled)
                    color.a = tex2D(_AlphaTex, uv).r;
                #endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED
                //Add your color here.
                color.rgb = _Color;;
                return color;
            }
            
            fixed4 frag (v2f i) : SV_Target
             {
                 return sample_sprite_texture(i.uv);
            }
            
            ENDCG
        }
    }
}
