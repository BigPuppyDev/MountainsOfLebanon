Shader "Custom/Shady" {
	 Properties 
 {
     _Color ("Main Color", Color) = (1,1,1,0.1)
     _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
 }
 
 Category 
 {
     SubShader 
     { 
         Tags { "Queue"="Transparent" }
 
         Pass
         {
             ZWrite Off
             ZTest Greater
             Lighting Off
             Color [_Color]
         }
         Pass 
         {
             ZTest Less          
             SetTexture [_MainTex] {combine texture}
         }
     }
 }
 
	FallBack "Transparent"
}
