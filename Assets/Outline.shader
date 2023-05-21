Shader "PostProcessing/Outline"
{
    HLSLINCLUDE
        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        TEXTURE2D_SAMPLER2D(_CameraDepthTexture, sampler_CameraDepthTexture);
        TEXTURE2D_SAMPLER2D(_CameraGBufferTexture2, sampler_CameraGBufferTexture2);

        float _OutlineThickness;
        float _OutlineDepthMultiplier;
        float _OutlineDepthBias;
        float _OutlineNormalMultiplier;
        float _OutlineNormalBias;

        float4 _OutlineColor;

    float4 Sample(Texture2D t, SamplerState s, float2 uv, float3 offset)
    {
        float4 pixelCenter = t.Sample(s, uv);
        float4 pixelLeft = t.Sample(s, uv - offset.xz);
        float4 pixelRight = t.Sample(s, uv + offset.xz);
        float4 pixelUp = t.Sample(s, uv + offset.zy);
        float4 pixelDown = t.Sample(s, uv - offset.zy);

        return abs(pixelLeft - pixelCenter) +
            abs(pixelRight - pixelCenter) +
            abs(pixelUp - pixelCenter) +
            abs(pixelDown - pixelCenter);
    }

    float Depth(float ldc, float ldl, float ldr, float ldu, float ldd)
    {
        return abs(ldl - ldc) +
            abs(ldr - ldc) +
            abs(ldu - ldc) +
            abs(ldd - ldc);
    }

    float SampleDepth(Texture2D t, SamplerState s, float2 uv, float3 offset)
    {
        float pixelCenter = LinearEyeDepth(t.Sample(s, uv).r);
        float pixelLeft   = LinearEyeDepth(t.Sample(s, uv - offset.xz).r);
        float pixelRight  = LinearEyeDepth(t.Sample(s, uv + offset.xz).r);
        float pixelUp     = LinearEyeDepth(t.Sample(s, uv + offset.zy).r);
        float pixelDown   = LinearEyeDepth(t.Sample(s, uv - offset.zy).r);

        return Depth(pixelCenter, pixelLeft, pixelRight, pixelUp, pixelDown);
    }

    float4 FragMain(VaryingsDefault i) : SV_Target
    {
        float3 offset = float3((1.0 / _ScreenParams.x), (1.0 / _ScreenParams.y), 0.0) * _OutlineThickness;
        float3 sceneColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord).rgb;

        float sobelDepth = SampleDepth(_CameraDepthTexture, sampler_CameraDepthTexture, i.texcoord.xy, offset);
        sobelDepth = pow(abs(saturate(sobelDepth) * _OutlineDepthMultiplier), _OutlineDepthBias);

        float3 sobelNormalVec = Sample(_CameraGBufferTexture2, sampler_CameraGBufferTexture2, i.texcoord.xy, offset).rgb;
        float sobelNormal = sobelNormalVec.x + sobelNormalVec.y + sobelNormalVec.z;
        sobelNormal = pow(abs(sobelNormal * _OutlineNormalMultiplier), _OutlineNormalBias);

        float sobelOutline = saturate(max(sobelDepth, sobelNormal));

        float3 outlineColor = lerp(sceneColor, _OutlineColor.rgb, _OutlineColor.a);
        float3 color = lerp(sceneColor, outlineColor, sobelOutline);

        return float4(color, 1.0);
    }
    
    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM
                #pragma vertex VertDefault
                #pragma fragment FragMain
            ENDHLSL
        }
    }
}