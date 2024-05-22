Shader "Unlit/SphereGrid"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1) // 主颜色
        _GridColor ("Grid Color", Color) = (0,0,0,1) // 网格颜色
        _GridWidth ("Grid Width", Range(0.01, 1)) = 0.02 // 网格宽度
        _GridHeight("Grid Height", Range(0.01, 1)) = 0.02 // 网格高度
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

            // 包含Unity的常用Shader库
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 localPos : TEXCOORD0; // 本地坐标
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 localPos : TEXCOORD1; // 本地坐标
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
                o.localPos = v.vertex.xyz; // 传递本地坐标
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 归一化本地坐标，以确保它们在单位球体上
                float3 pos = normalize(i.localPos);

                // 计算球面坐标
                float latitude = acos(pos.y); // 纬度
                float longitude = atan2(pos.z, pos.x); // 经度

                // 将球面坐标转换为纹理坐标
                float u = longitude / (2.0 * UNITY_PI) + 0.5;
                float v = latitude / UNITY_PI;

                // 计算网格效果
                float gridU = abs(frac(u / _GridHeight) - 0.5) / (_GridHeight / 2.0);
                float gridV = abs(frac(v / _GridWidth) - 0.5) / (_GridWidth / 2.0);
                float grid = min(gridU, gridV);

                // 线性插值计算颜色
                fixed4 color = lerp(_Color, _GridColor, step(0.5, grid));
                
                // 返回最终颜色
                return color;
            }
            ENDCG
        }
    }
    FallBack "Unlit/Texture"
}
