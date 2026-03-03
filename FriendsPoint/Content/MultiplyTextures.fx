sampler2D TextureA : register(s0);
sampler2D TextureB : register(s1);

float2 Offset; // смещение второй текстуры (UV)
float4 MultiplyPS(float2 uv : TEXCOORD0) : COLOR0
{
    float4 a = tex2D(TextureA, uv);
    float4 b = tex2D(TextureB, uv);

    // для дебага — показать маску
    // return float4(b.rgb, b.a);

    float alpha = a.a * b.a;
    float3 color = a.rgb * b.a; // маска влияет и на цвет
    return float4(color, alpha);
}
technique Multiply
{
    pass P0
    {
        PixelShader = compile ps_2_0 MultiplyPS();
    }
}