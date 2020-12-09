<template>
    <div class="container">
        <form class="form-login" @submit.prevent="login">
            <h1>Login</h1>
            <label for="email">Email:</label><br>
            <input id="email" required v-model="email" type="text" placeholder="Enter Email"/>
            <br>
            <label for="email">Password:</label><br>
            <input id="password" required v-model="password" type="password" placeholder="Enter Password"/>
            <button type="submit">Login</button><br>
            <router-link :to="{ name: 'frontpage' }"
               tabindex="0"
            > 
                <button>Back</button>
            </router-link>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                email: '',
                password: ''
            };
        },
        methods: {
            login() {
                const email = this.email;
                const password = this.password;

                this.$store.dispatch('login', { email, password })
                    .then(() => {
                        this.$router.push({ name: 'frontpage' }) // TODO: Update route name
                    }).catch(() => {
                        console.log('Noget gik galt!')
                    });
            },
            gotofrontpage: function() {
                this.$router.push({ name: 'frontpage' })
            }
        }
    }
</script>

<style scoped>
    h1 {
        padding: 0px;
        margin: 0px;
        margin-bottom: 1em;
    }

  input {
        width: 80%;
        margin: 1em;
        padding: 2px;
        border: 2px solid white;
        border-radius: 5px;
        transition: all ease 0.5s;
    }

    input:focus {
        background-color: black;
        color: white;
        border-color: white
    }

    label {
        margin: 0px;
        padding: 0px;
    }

    button {
        padding-left: 2em;
        padding-right: 2em;
        transition: all ease-in 0.5s;
        border-radius: 5px;
        color: white;
        background-color: black;
        border: 2px solid white;
        margin: 5px;
    }

    button:hover {
        padding-left: 4em;
        padding-right: 4em;
        border-radius: 5px;
    }

    .container{
        padding: 1em;
        text-align: center;
        color: white;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
    }

    .form-login {
        border: 2px solid white;
        display: table;
        margin: 0 auto;
        width: 20em;
        border-radius: 1em;
        padding: 1em;
    }
</style>