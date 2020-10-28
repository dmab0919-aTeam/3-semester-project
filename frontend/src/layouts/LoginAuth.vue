<template>
 <div>
   <form class="login" @submit.prevent="login">
     <h1>Sign in</h1>
     <label>User name</label>
     <input required v-model="email" type="text" placeholder="Snoopy"/>
     <label>Password</label>
     <input required v-model="password" type="password" placeholder="Password"/>
     <hr/>
     <button type="submit">Login</button>
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
            }
        }

    }
</script>