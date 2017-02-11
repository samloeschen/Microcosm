Shader "Masked/Mask" {

	SubShader{
		// Render the mask after regular geometry, but before masked geometry and
		// transparent things.

		Tags{ "Queue" = "Overlay+10" }

		// Don't draw in the RGBA channels; just the depth buffer

		ZWrite On
		ZTest Always

		Pass{

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};
			float _Radius;
			v2f vert(appdata v) {
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			half4 frag(v2f i) : SV_Target{
				float2 delta = i.uv - 0.5;
				clip(dot(delta, delta) - 0.17);
				return half4(0, 0, 0, 0);
			}
			ENDCG
		}
	}
}