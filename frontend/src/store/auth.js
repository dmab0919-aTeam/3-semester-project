import axios from 'axios';

export default {
    state: {
        status: "",
        token: localStorage.getItem("token") || "",
        user: {}
    },
    mutations: {
        auth_request(state) {
            state.status = "loading";
        },
        auth_success(state, token, user) {
            state.status = "success";
            state.token = token;
            state.user = user;
        },
        auth_error(state) {
            state.status = "error";
        },
        logout(state) {
            state.status = "";
            state.token = "";
        }
    },
    actions: {
        login({ commit }, { email, password }) {
            return new Promise((resolve, reject) => {
                commit('auth_request');
                axios.post('auth/login', {
                    email: email,
                    password: password
                })
                    .then(response => {
                        const token = response.data.Key,
                            user = response.data.user;
                        localStorage.setItem("token", token);
                        localStorage.setItem("userId", response.data.userId);
                        axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
                        commit("auth_success", token, user);
                        resolve(response);
                    }).catch(error => {
                        commit("auth_error");
                        localStorage.removeItem("token");
                        reject(error);
                    })
            });
        },
        logout({ commit }) {
            return new Promise(resolve => {
                commit("logout");
                localStorage.removeItem("token");
                delete axios.defaults.headers.common["Authorization"];
                resolve();
            });
        }
    },
    getters: {
        isLoggedIn: state => !!state.token,
        authStatus: state => state.status
    }
};