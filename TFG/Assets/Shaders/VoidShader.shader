Shader "Unlit/VoidShader"
{

	Properties
	{
		_MainTex("Color (RGB) Alpha (A)", 2D) = "white" {}
		_WaveSpeed("WaveSpeed", Range(-1000, 1000)) = 20
		_Frequency("Frequency", Range(0, 100)) = 10
		_Amplitude("Amplitude", Range(0, 3)) = 0.02
		_RedScale("Red Scale", Range(0, 3)) = 1
		_GreenScale("Green Scale", Range(0, 3)) = 1
		_BlueScale("Blue Scale", Range(0, 3)) = 1
	}
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

			static float2 size = float2(0.5, 0.1);
			static float2 distortion = float2(4.2, 3.9);
			static float speed = 0.02;

			fixed _Frequency;
			fixed _WaveSpeed;
			fixed _Amplitude;
			fixed _RedScale;
			fixed _GreenScale;
			fixed _BlueScale;


			fixed4 frag(v2f i) : SV_Target
			{
				float2 uv = float2(i.uv.x, 1 - i.uv.y);

				float2 transformed = float2(
					uv.x + sin(uv.y / size.x + _Time.y * speed) * distortion.x,
					uv.y + cos(uv.x / size.y + _Time.y * speed) * distortion.y
					);

				fixed2 uvs = i.uv;
				fixed4 col = tex2D(_MainTex, transformed / uv);
				fixed d = sin(uvs.y * _Frequency + _Time * _WaveSpeed) * _Amplitude;
				col.r += d * _RedScale;
				col.g += d * _GreenScale;
				col.b += d * _BlueScale;

				uvs = i.uv;
				//col = tex2D(_MainTex, transformed);
				d = sin(sin(uvs.x * _Frequency + _Time * _WaveSpeed)) * _Amplitude / 3.0;
				col.r += d * _RedScale;
				col.g += d * _GreenScale;
				col.b += d * _BlueScale;

				uvs = i.uv;
				//col = tex2D(_MainTex, transformed);
				d = tan(cos(uvs.x * _Frequency + _Time * _WaveSpeed)) * _Amplitude / 10.0;
				col.r += d * _RedScale;
				col.g += d * _GreenScale;
				col.b += d * _BlueScale;

				
				return col;

				/*return tex2D(_MainTex, transformed) + float4(
					(cos(uv.x + _Time.y * speed2 * 3.0) + 1.0) / 2.0,
					(uv.x + uv.y) / 2.0,
					(sin(uv.y + _Time.y * speed2) + 1.0) / 2.0,
					0
					);
					*/
			}
            ENDCG
        }
    }
}
