Shader "Custom/InvisibleShadowCaster" {
    SubShader {
         Tags { "Queue"="Transparent" "RenderType"="Transparent"}

        //cast shader
        UsePass "VertexLit/SHADOWCASTER"
        }
    FallBack off
}