Shader "Sam Loeschen/CircleFill" {

	Properties{
		_Color("_Color", Color) = (1,1,1)
		_Alpha("_Alpha", Range(0, 1)) = 1
	}

		SubShader{

			Tags{ "RenderType" = "Opaque" "Queue" = "Transparent-20" }

			Blend SrcAlpha OneMinusSrcAlpha
			Pass{
				Name "CircleFill"
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#include "UnityCG.cginc"

				struct appdata {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f {
					float2  uv : TEXCOORD0;
					float4  vertex : SV_POSITION;
				};

				v2f vert(appdata v) {
					v2f o;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv = v.uv;
					return o;
				}

				half3 _Color;
				float _Alpha;

				half4 frag(v2f i) : COLOR{

					float2 delta = i.uv - 0.5;
					clip(0.25 - dot(delta, delta));
					return half4(_Color, _Alpha);

				}

			ENDCG
		}
	}
}
