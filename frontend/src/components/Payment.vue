<template>
  <div>
    <form @submit.prevent="">
      <label> CARD NUMBER
        <input
            type="tel"
            class="form-control"
            name="cardNumber"
            placeholder="Valid Card Number"
            autocomplete="cc-number"
            required autofocus
        />
      </label>
      <label> EXPIRATION
        <input
            type="tel"
            class="form-control"
            name="cardExpiry"
            placeholder="MM / YY"
            autocomplete="cc-exp"
            required
        />
      </label>

      <label>CV CODE
      <input
          type="tel"
          class="form-control"
          name="cardCVC"
          placeholder="CVC"
          autocomplete="cc-csc"
          required
      />
      </label>

      <button @click.prevent="ProcessPayment" type="submit">Pay</button>
    </form>
    <div>
        <p v-if="data.hasError">{{ this.data.errorMessage }}</p>
        <button v-if="data.hasError" @click="$router.go(-2)" type="button">Return</button>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: "Payment",
  data() {
    return {
      data: {
        hasError: false,
        errorMessage: "",
      } 
      
    }
  },
  methods: {
    ProcessPayment() {
      console.log(this.$route.params.key)
        axios.post('order', {
          UUID: this.$route.params.key,
          ShowingID: (1 * this.$route.params.showingid),
          UserID:  localStorage.getItem("userId"),
          seats: JSON.parse(this.$route.params.seats)
        }).then(response => {
          console.log(response)
        }).catch(err => {
            this.data.errorMessage = "You were too slow, someone else took your seats. Press the button to return";
            this.data.hasError = true;
            console.log(err)
        })
    }
    
  },
  created() {
    
  }
}
</script>

<style scoped>

</style>