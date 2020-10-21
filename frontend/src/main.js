import Vue from 'vue'
import App from './App.vue'
import Axios from 'axios'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import router from './router'

// Install BootstrapVue
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

Vue.prototype.$http = Axios;

Axios.defaults.baseURL = "http://localhost:5000/api";

Vue.config.productionTip = false

new Vue({
  router,
  el: "#app",
  render: h => h(App)
}).$mount('#app');
