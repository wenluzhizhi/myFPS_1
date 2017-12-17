Shader "Custom/SoliderSkin" {
	Properties{
	   _MainTex("MainTex",2D)="white"{}
	   _Bump("Bump",2D)="Bump"{}
	}
	Subshader{
	   pass{

	     stencil{
	        Ref 1
	        pass keep
	     }

         // ztest greater
	      CGPROGRAM
	      #pragma vertex vert
	      #pragma fragment frag
	      #include "unitycg.cginc"

	      sampler2D _MainTex;
	      struct a2v{
	        float4 vertex:POSITION;
	        float4 texcoord:TEXCOORD;
	      };

	      struct v2f{
	        float4 pos:SV_POSITION;
	        float2 uv:TEXCOORD0;
	      };

	      v2f vert(a2v v){
	        v2f o;
	        o.pos=mul(UNITY_MATRIX_MVP,v.vertex);
	        o.uv=v.texcoord.xy;
	        return o;
	      }

	      fixed4 frag(v2f i):SV_Target{
	        fixed4 col=fixed4(1,1,1,1);
	        col=tex2D(_MainTex,i.uv);
	        return col;

	      }

	      ENDCG
	   }

	   pass{
	        stencil{
	        Ref 1
	        comp Equal
	        pass keep
	      }
          //ztest greater
	      CGPROGRAM
	      #pragma vertex vert
	      #pragma fragment frag
	      #include "unitycg.cginc"

	      sampler2D _MainTex;
	      struct a2v{
	        float4 vertex:POSITION;
	        float4 texcoord:TEXCOORD;
	      };

	      struct v2f{
	        float4 pos:SV_POSITION;
	        float2 uv:TEXCOORD0;
	      };

	      v2f vert(a2v v){
	        v2f o;
	        o.pos=mul(UNITY_MATRIX_MVP,v.vertex);
	        o.uv=v.texcoord.xy;
	        return o;
	      }
	      fixed4 frag(v2f i):SV_Target{
	        fixed4 col=fixed4(1,0,0,0);
	        //col=tex2D(_MainTex,i.uv);
	        return col;
	      }
	      ENDCG
	   }

	    
	}
}
