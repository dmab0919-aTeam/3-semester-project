<template>
<div>
  <div class="seatStructure">
<center>
<table id="seatsBlock">
 <p id="notification"></p>
  <tr>
    <td colspan="14"><div class="screen">SCREEN</div></td>
    <td rowspan="20">
      <div class="smallBox greenBox">Selected Seat</div> <br/>
      <div class="smallBox redBox">Reserved Seat</div><br/>
      <div class="smallBox emptyBox">Empty Seat</div><br/>
    </td>
    <br/>
  </tr>
  
  <tr>
    <td></td>
    <td v-for="(item, key) in this.data.seatdata" v-bind:key="key">
      {{key+1}}
    </td>
</tr>

<tr v-for="(item, key) in this.data.seatdata" v-bind:key="key">
    <td>{{key + 1}}</td>
    <td v-for="(seat, kei) in item" v-bind:key="kei">
      <input v-if="seat.status === 'Empty'" type="checkbox" class="seats" @change="selectSeat(seat.rowNumber, seat.seatNumber)">
      <div v-else class="smallBox redBox"></div>
    </td>
</tr>
</table>
</center>
</div>
</div>
</template>

<script>
import axios from "axios";

export default {
  name: "SeatPicker",

   props: {
        selectedSeats: Array,
        showingId: Number
    },
  
  data() {
    return {
      data: {
          seatdata: null,  
          counter: ''
      }
    }
  },
  
  methods: {
    generateSeats: function() {
      let result = []

      for(let i=0; i<10; i++){
        result.push([])
        for(let j = 0; j < 10; j++) {
          result[i].push({
            seatNumber: j,
            rowNumber: i,
            status: 'Empty'
          })
        }
      }
      this.data.seatdata = result
    },
    reservedSeat: function(rownumber, seatnumber) {
  
      seatnumber = seatnumber - 1
      rownumber = rownumber - 1
      this.data.seatdata[rownumber][seatnumber].status = "df"

    },
    selectSeat: function(rowNumber, seatNumber){
      let arrayIndex = null;
      rowNumber = rowNumber + 1
      seatNumber = seatNumber + 1
      this.selectedSeats.forEach(function(value,index){
        if(value.row === rowNumber && value.number === seatNumber){
          arrayIndex = index
        }
      });
      if(arrayIndex != null){
        this.selectedSeats.splice(arrayIndex, 1)
      }

      if(arrayIndex === null){
        this.selectedSeats.push({
          number: seatNumber,
          row: rowNumber
        });
      }
    },

    removeSelectedSeats(element) {
      let arrayindex = null
      this.selectedSeats.forEach(function(i, index) {
        if(i.number === element.number && i.row === element.row){
          arrayindex = index
        }
      });
      if(arrayindex != null){
        this.selectedSeats.splice(arrayindex, 1)
      }

    },
    
    fetchReservedSeats() {
      this.generateSeats()
      axios.get(`seat/${this.showingId}`).then(response => {
        if(Array.isArray(response.data)){
          response.data.forEach(element => {
          this.removeSelectedSeats(element)
          this.reservedSeat(element.row, element.number)
        });
        }
      }).catch(err => {
        console.log(err)
      });
    },
  },

  created() {
    this.generateSeats()
    this.fetchReservedSeats()
    this.data.counter = setInterval(() => this.fetchReservedSeats(), 10000)
  },

  beforeDestroy() {
    clearInterval(this.data.counter)
  }
}
</script>

<style scoped>
body
{
  font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
}
#Username
{
  border:none;
  border-bottom:1px solid;
}
.screen
{
  width:100%;
  height:20px;
  background:#4388cc;
  color:#fff;
  line-height:20px;
  font-size:15px;
}
.smallBox::before
{
  content:".";
  width:15px;
  height:15px;
  float:left;
  margin-right:10px;
}
.greenBox::before
{
  content:"";
  background:Green;
}
.redBox::before
{
  content:"";
  background:Red;
}
.emptyBox::before
{
  content:"";
  box-shadow: inset 0px 2px 3px 0px rgba(0, 0, 0, .3), 0px 1px 0px 0px rgba(255, 255, 255, .8);
    background-color:#ccc;
}
.seats
{
  border:1px solid red;background:yellow;
} 
.seatGap
{
  width:40px;
}
.seatVGap
{
  height:40px;
}
table
{
  text-align:center;
}
.Displaytable
{
  text-align:center;
}
.Displaytable td, .Displaytable th {
    border: 1px solid;
    text-align: left;
}
textarea
{
  border:none;
  background:transparent;
}
input[type=checkbox] {
    width:0px;
    margin-right:18px;
}
input[type=checkbox]:before {
    content: "";
    width: 15px;
    height: 15px;
    display: inline-block;
    vertical-align:middle;
    text-align: center;
    box-shadow: inset 0px 2px 3px 0px rgba(0, 0, 0, .3), 0px 1px 0px 0px rgba(255, 255, 255, .8);
    background-color:#ccc;
}
input[type=checkbox]:checked:before {
    background-color:Green;
    font-size: 15px;
}
</style>