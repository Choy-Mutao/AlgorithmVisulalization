Shader "Unlit/SphereGrid"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1) // ����ɫ
        _GridColor ("Grid Color", Color) = (0,0,0,1) // ������ɫ
        _GridWidth ("Grid Width", Range(0.01, 1)) = 0.02 // ������
        _GridHeight("Grid Height", Range(0.01, 1)) = 0.02 // ����߶�
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

            // ����Unity�ĳ���Shader��
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 localPos : TEXCOORD0; // ��������
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 localPos : TEXCOORD1; // ��������
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _GridColor;
            float _GridWidth;
            float _GridHeight;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.localPos = v.vertex.xyz; // ���ݱ�������
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // ��һ���������꣬��ȷ�������ڵ�λ������
                float3 pos = normalize(i.localPos);

                // ������������
                float latitude = acos(pos.y); // γ��
                float longitude = atan2(pos.z, pos.x); // ����

                // ����������ת��Ϊ��������
                float u = longitude / (2.0 * UNITY_PI) + 0.5;
                float v = latitude / UNITY_PI;

                // ��������Ч��
                float gridU = abs(frac(u / _GridHeight) - 0.5) / (_GridHeight / 2.0);
                float gridV = abs(frac(v / _GridWidth) - 0.5) / (_GridWidth / 2.0);
                float grid = min(gridU, gridV);

                // ���Բ�ֵ������ɫ
                fixed4 color = lerp(_Color, _GridColor, step(0.5, grid));
                
                // ����������ɫ
                return color;
            }
            ENDCG
        }
    }
    FallBack "Unlit/Texture"
}
