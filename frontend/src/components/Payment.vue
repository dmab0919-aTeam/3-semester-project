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
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: "Payment",
  data() {
    return {
      
    }
  },
  methods: {
    ProcessPayment() {
        axios.post('order', {
          ShowingID: (1 * this.$route.params.showingid),
          UserID: 3,
          seats: JSON.parse(this.$route.params.seats)
        }).then(response => {
          console.log(response)
        })
    }
  },
  created() {
    
  }
}
</script>

<style scoped>

</style>