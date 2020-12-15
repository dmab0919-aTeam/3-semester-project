<template>
  <div>
    
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Ticket",
  data() {
    return {
      data: {
        totalPrice: '',
        seats: []
      }

    }
  },
  methods: {
    fetchOrder() {
      console.log(this.$route.params.key)
      axios.get(`order/${this.$route.params.showingid}`).then(response => {
        console.log(response)
        this.data.totalPrice = response.data.totalPrice
      }).catch(err => {
        this.data.errorMessage = "You were too slow, someone else took your seats. Press the button to return";
        this.data.hasError = true;
        console.log(err)
      })
    },
    fetchseats() {
      console.log(this.$route.params.key)
      axios.get(`seat/order/${this.$route.params.orderId}`).then(response => {
        console.log(response)
        this.data.seats = response.data
      }).catch(err => {
        this.data.errorMessage = "You were too slow, someone else took your seats. Press the button to return";
        this.data.hasError = true;
        console.log(err)
      })
    }

  },
  created() {
    this.fetchOrder()
    this.fetchseats()
  }
}
</script>

<style scoped>

</style>