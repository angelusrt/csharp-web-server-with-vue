<template>
  <div class="home">
    <Alert :show="alertShow" :type="alertType" :message="alertMessage" :dismiss="dismissAlert"/>
    <h1>Pokemon Inicial Favorito</h1>
    <h3>{{total}} votos computados</h3>
    <label>Digite um pseudônimo</label>
    <input rows="1" v-model="pseudonym"/>
    <div class="vote-list">
      <VoteEl :votes="votes[0][0]" :pseudonym="pseudonym" name="squirtle" :postVote="postVote"/>
      <VoteEl :votes="votes[0][1]" :pseudonym="pseudonym" name="charmander" :postVote="postVote"/>
      <VoteEl :votes="votes[0][2]" :pseudonym="pseudonym" name="bulbasaur" :postVote="postVote"/>
    </div>
  </div>
</template>

<script lang="ts">
  import Vue, {ref} from 'vue'
  import api, {Data} from '../api'
  import Alert from '../components/Alert.vue'
  import VoteEl from '../components/VoteEl.vue'

  export default Vue.extend({
    name: "HomeView",
    components: { VoteEl, Alert },
    data() {
      return {
        total: 0,
        votes: [[0, 0, 0]],
        pseudonym: '',
        alertShow: false,
        alertType: 'success',
        alertMessage: ''
      }
    },
    methods: {
      async getVotes(){ 
        try {
          let result = await api.get() 

          if( 
            typeof result !== "undefined" && result != null && 
            result.length != 0 && result[0] != null && result[0].length === 3
          ){
            this.votes = result
            this.total = this.votes[0][0] + this.votes[1][0] + this.votes[2][0]
            console.log('yey votes')

            this.alertShow = true
            this.alertType = 'success'
            this.alertMessage = 'votos acessados'
          } 
          else {
            throw new Error("null")

          }
        } catch (err) {
          console.log(err)

          this.alertShow = true
          this.alertType = 'error'
          this.alertMessage = 'houve um error ao acessar o banco de dados'
        }
      },
      async postVote(data: Data){ 
        try {
          let result = await api.post(data) 
          console.log('yey votes')

          this.alertShow = true
          this.alertType = 'success'
          this.alertMessage = 'votos acessados'
        } catch (err) {
          console.log(err)

          this.alertShow = true
          this.alertType = 'error'
          this.alertMessage = 'houve um error ao acessar o banco de dados'

          console.log(this)
        }
      },
      dismissAlert() {
        this.alertShow = false
      }
    },
    mounted() {
      this.getVotes()
    }
  })
</script>

<style>
  .home {
    display: flex;
    flex-direction: column;
  }
  .vote-list {
    display: flex;
    flex-wrap: wrap;
    margin: 40px auto 0 auto;
    padding: 20px;
    background-color: #2c3e50;
    width: calc(100% - 40px);
  }

  input {
    border-radius: 10px;
    margin: 5px auto;
    color: #fff;
    border: 2px solid #2c3e50;
    background-color: #1f2d40;
    text-align: center;
    padding: 10px;
    resize: none;
    max-width: 200px;
    height: 30px;
    font-size: 20px;
  }
</style>
