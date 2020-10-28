import Vue from 'vue'
import App from './App.vue'
import Axios from 'axios'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import router from './router'
import store from './store'

// Install BootstrapVue
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

Vue.prototype.$http = Axios;

Axios.defaults.baseURL = "http://localhost:5000/api";

Vue.config.productionTip = false

const token = localStorage.getItem("token");
if (token)
    Vue.prototype.$http.defaults.headers.common["Authorization"] = `Bearer ${token}`;


new Vue({
  store,
  router,
  el: "#app",
  render: h => h(App)
}).$mount('#app');
