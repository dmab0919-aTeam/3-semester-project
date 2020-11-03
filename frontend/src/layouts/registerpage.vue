<template>
    <div class="container">
        <div class="form-container">
            <form class="form">
                <label>First name:</label>
                <input id="firstname" type="text"><br>
                <label>Last name:</label>
                <input id="lastname" type="text"><br>
                <label>Email:</label>
                <input id="email" type="email"><br>
                <label>Phone number:</label>
                <input id="phonenumber" type="text"><br>
                <label>Password:</label>
                <input id="password" type="password"><br>
                <button type="submit">Register</button><br>
                <router-link :to="{ name: 'frontpage' }" tabindex="0"> 
                    <button>Back</button>
                </router-link>
            </form>
        </div>
    </div>
</template>

<script>

export default {
    
}

</script>

<style scoped>

    label{
        color: white;
    }

    .container{
        border: 2px solid green; 
    }

</style>