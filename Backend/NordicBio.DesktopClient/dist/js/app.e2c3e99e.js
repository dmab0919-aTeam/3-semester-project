(function(e){function t(t){for(var r,o,c=t[0],i=t[1],s=t[2],l=0,f=[];l<c.length;l++)o=c[l],Object.prototype.hasOwnProperty.call(a,o)&&a[o]&&f.push(a[o][0]),a[o]=0;for(r in i)Object.prototype.hasOwnProperty.call(i,r)&&(e[r]=i[r]);d&&d(t);while(f.length)f.shift()();return u.push.apply(u,s||[]),n()}function n(){for(var e,t=0;t<u.length;t++){for(var n=u[t],r=!0,o=1;o<n.length;o++){var c=n[o];0!==a[c]&&(r=!1)}r&&(u.splice(t--,1),e=i(i.s=n[0]))}return e}var r={},o={app:0},a={app:0},u=[];function c(e){return i.p+"js/"+({}[e]||e)+"."+{"chunk-0499215e":"53d9f23a","chunk-42f2aded":"72948f32","chunk-57f59dc6":"648bdcb7","chunk-6785ee1a":"a8e84b36","chunk-679b46d8":"50563b8c","chunk-930f1df6":"9aded2c9"}[e]+".js"}function i(t){if(r[t])return r[t].exports;var n=r[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,i),n.l=!0,n.exports}i.e=function(e){var t=[],n={"chunk-0499215e":1,"chunk-42f2aded":1,"chunk-57f59dc6":1,"chunk-6785ee1a":1,"chunk-679b46d8":1,"chunk-930f1df6":1};o[e]?t.push(o[e]):0!==o[e]&&n[e]&&t.push(o[e]=new Promise((function(t,n){for(var r="css/"+({}[e]||e)+"."+{"chunk-0499215e":"7aee40f9","chunk-42f2aded":"0cde50d6","chunk-57f59dc6":"13e06206","chunk-6785ee1a":"27ada0b7","chunk-679b46d8":"c4df2573","chunk-930f1df6":"f56c1fa0"}[e]+".css",a=i.p+r,u=document.getElementsByTagName("link"),c=0;c<u.length;c++){var s=u[c],l=s.getAttribute("data-href")||s.getAttribute("href");if("stylesheet"===s.rel&&(l===r||l===a))return t()}var f=document.getElementsByTagName("style");for(c=0;c<f.length;c++){s=f[c],l=s.getAttribute("data-href");if(l===r||l===a)return t()}var d=document.createElement("link");d.rel="stylesheet",d.type="text/css",d.onload=t,d.onerror=function(t){var r=t&&t.target&&t.target.src||a,u=new Error("Loading CSS chunk "+e+" failed.\n("+r+")");u.code="CSS_CHUNK_LOAD_FAILED",u.request=r,delete o[e],d.parentNode.removeChild(d),n(u)},d.href=a;var h=document.getElementsByTagName("head")[0];h.appendChild(d)})).then((function(){o[e]=0})));var r=a[e];if(0!==r)if(r)t.push(r[2]);else{var u=new Promise((function(t,n){r=a[e]=[t,n]}));t.push(r[2]=u);var s,l=document.createElement("script");l.charset="utf-8",l.timeout=120,i.nc&&l.setAttribute("nonce",i.nc),l.src=c(e);var f=new Error;s=function(t){l.onerror=l.onload=null,clearTimeout(d);var n=a[e];if(0!==n){if(n){var r=t&&("load"===t.type?"missing":t.type),o=t&&t.target&&t.target.src;f.message="Loading chunk "+e+" failed.\n("+r+": "+o+")",f.name="ChunkLoadError",f.type=r,f.request=o,n[1](f)}a[e]=void 0}};var d=setTimeout((function(){s({type:"timeout",target:l})}),12e4);l.onerror=l.onload=s,document.head.appendChild(l)}return Promise.all(t)},i.m=e,i.c=r,i.d=function(e,t,n){i.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},i.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},i.t=function(e,t){if(1&t&&(e=i(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(i.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var r in e)i.d(n,r,function(t){return e[t]}.bind(null,r));return n},i.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return i.d(t,"a",t),t},i.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},i.p="/",i.oe=function(e){throw console.error(e),e};var s=window["webpackJsonp"]=window["webpackJsonp"]||[],l=s.push.bind(s);s.push=t,s=s.slice();for(var f=0;f<s.length;f++)t(s[f]);var d=l;u.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("56d7")},"034f":function(e,t,n){"use strict";var r=n("85ec"),o=n.n(r);o.a},"1eb5":function(e,t,n){},"56d7":function(e,t,n){"use strict";n.r(t);n("e260"),n("e6cf"),n("cca6"),n("a79d");var r=n("2b0e"),o=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{attrs:{id:"app"}},[n("router-view"),n("Footer")],1)},a=[],u=function(){var e=this,t=e.$createElement;e._self._c;return e._m(0)},c=[function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"footer"},[n("div",{staticClass:"footer-content"},[n("p",{staticClass:"footer-text"},[e._v(" Contact | About | Membership Prices | Booking | Movies "),n("br"),e._v(" © nordicbioaalborg | Designed by @The-A-Team ")])])])}],i={},s=i,l=(n("e8bc"),n("2877")),f=Object(l["a"])(s,u,c,!1,null,"476a97e9",null),d=f.exports,h={components:{Footer:d},name:"App"},p=h,m=(n("034f"),Object(l["a"])(p,o,a,!1,null,null,null)),g=m.exports,v=n("bc3a"),b=n.n(v),k=n("5f5b"),y=n("b1e0"),w=n("8c4f"),_=(n("d3b7"),function(){return n.e("chunk-57f59dc6").then(n.bind(null,"0d14"))}),S=function(){return n.e("chunk-679b46d8").then(n.bind(null,"d268"))},A=function(){return n.e("chunk-6785ee1a").then(n.bind(null,"1108"))},O=function(){return n.e("chunk-930f1df6").then(n.bind(null,"1377"))},P=function(){return n.e("chunk-0499215e").then(n.bind(null,"8def"))},j=function(){return n.e("chunk-42f2aded").then(n.bind(null,"899d"))},E=[{path:"/",name:"frontpage",component:_},{path:"/login",name:"login",component:S,meta:{requiresAuth:!1}},{path:"/movie/:id",name:"singleMovie",component:A},{path:"/movieseat/:id/:showingid",name:"singleMovieSeat",component:O},{path:"/register",name:"register",component:P,meta:{requiresAuth:!1}},{path:"/admin",name:"adminPanel",component:j,meta:{requiresAuth:!0}}],C=E;r["default"].use(w["a"]);var x=new w["a"]({mode:"history",routes:C}),T=x,M=n("2f62"),q=(n("99af"),{state:{status:"",token:localStorage.getItem("token")||"",user:{}},mutations:{auth_request:function(e){e.status="loading"},auth_success:function(e,t,n){e.status="success",e.token=t,e.user=n},auth_error:function(e){e.status="error"},logout:function(e){e.status="",e.token=""}},actions:{login:function(e,t){var n=e.commit,r=t.email,o=t.password;return new Promise((function(e,t){n("auth_request"),console.log(r+o),b.a.post("auth/login?email=".concat(r,"&password=").concat(o)).then((function(t){var r=t.data.Key,o=t.data.user;localStorage.setItem("token",r),b.a.defaults.headers.common["Authorization"]="Bearer ".concat(r),n("auth_success",r,o),e(t)})).catch((function(e){n("auth_error"),localStorage.removeItem("token"),t(e)}))}))},logout:function(e){var t=e.commit;return new Promise((function(e){t("logout"),localStorage.removeItem("token"),delete b.a.defaults.headers.common["Authorization"],e()}))}},getters:{isLoggedIn:function(e){return!!e.token},authStatus:function(e){return e.status}}});r["default"].use(M["a"]);var I=new M["a"].Store({modules:{auth:q}});r["default"].use(k["a"]),r["default"].use(y["a"]),r["default"].prototype.$http=b.a,b.a.defaults.baseURL="http://localhost:5000/api",r["default"].config.productionTip=!1;var L=localStorage.getItem("token");L&&(r["default"].prototype.$http.defaults.headers.common["Authorization"]="Bearer ".concat(L)),new r["default"]({store:I,router:T,el:"#app",render:function(e){return e(g)}}).$mount("#app")},"85ec":function(e,t,n){},e8bc:function(e,t,n){"use strict";var r=n("1eb5"),o=n.n(r);o.a}});
//# sourceMappingURL=app.e2c3e99e.js.map