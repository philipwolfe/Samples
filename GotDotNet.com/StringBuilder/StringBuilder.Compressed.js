﻿StringBuilder=function(A){var h=new Array();if(A){h[0]=A;}this.Append=Append;this.AppendLine=AppendLine;this.ToString=ToString;this.Clear=Clear;this.Length=Length;this.Replace=Replace;this.Remove=Remove;this.Insert=Insert;this.GetType=GetType;function Append(s){h[h.length]=s;}function AppendLine(s){h[h.length]=s;h[h.length]="\r\n";}function ToString(){if(!h){return "";}if(h.length<2){return (h[0])?h[0]:"";}var a=h.join('');h=new Array();h[0]=a;return a;}function Clear(){h=new Array();}function Length(){if(!h){return 0;}if(h.length<2){return (h[0])?h[0].length:0;}var a=h.join('');h=new Array();h[0]=a;return a.length;}function Replace(o,n,c){var r=new RegExp(o,(c==true)?'g':'gi');var b=h.join('').replace(r,n);h=new Array();h[0]=b;return this;}function Remove(i,l){var s=h.join('');h=new Array();if(i<1){h[0]=s.substring(l,s.length);}if(i>s.length){h[0]=s;}else{h[0]=s.substring(0,i);h[1]=s.substring(i+l,s.length);}return this;}function Insert(i,v){var s=h.join('');h=new Array();if(i<1){h[0]=v;h[1]=s;}if(i>=s.length){h[0]=s;h[1]=v;}else{h[0]=s.substring(0,i);h[1]=v;h[2]=s.substring(i,s.length);}return this;}function GetType(){return "StringBuilder";}};