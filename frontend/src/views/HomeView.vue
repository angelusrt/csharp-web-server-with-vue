<template>
  <div class="home">
    <Alert :show="alertShow" :type="alertType" :message="alertMessage" :dismiss="dismissAlert"/>
    <label>Digite um pseudônimo</label>
    <input rows="1" v-model="pseudonym"/>
    <div class="vote-list">
      <VoteEl :votes="votes[0]" :pseudonym="pseudonym" name="squirtle" :postVote="postVote"/>
      <VoteEl :votes="votes[1]" :pseudonym="pseudonym" name="charmander" :postVote="postVote"/>
      <VoteEl :votes="votes[2]" :pseudonym="pseudonym" name="bulbasaur" :postVote="postVote"/>
    </div>
    <h3>{{total}} votos computados</h3>
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
        votes: [0, 0, 0],
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
          console.log(result)

          if( 
            typeof result !== "undefined" && result != null && result.length === 3 && 
            typeof result[0] === "number" && typeof result[1] === "number" && typeof result[2] === "number"
          ){
            this.votes = result
            this.total = this.votes[0] + this.votes[1] + this.votes[2]

            console.log('yey votes')
            this.alertShow = true
            this.alertType = 'success'
            this.alertMessage = 'votos acessados'
          } else { throw new Error(''+result) }
        } catch (err) {
          console.log(err)
          this.alertShow = true
          this.alertType = 'error'
          this.alertMessage = 'houve um error ao acessar o banco de dados'
        }
      },
      async postVote(data: Data){ 
        try {
          if (data.pseudonym === ""){ throw new Error("no-name") }

          let result = await api.post(data) 
          console.log(result)

          if(result !== "Your vote was computed") { throw new Error(result) }

          console.log('yey votes')
          this.alertShow = true
          this.alertType = 'success'
          this.alertMessage = 'voto computado'

        } catch (err) {
          console.log(err)
          this.alertShow = true
          this.alertType = 'error'

          this.alertMessage = (err as Error).message === 'no-name' ? 
            'digite um pseudônimo' : 'houve um error ao acessar o banco de dados'
        }
      },
      dismissAlert() { this.alertShow = false }
    },
    mounted() { this.getVotes() }
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
    margin-left: -20px;
    padding: 20px 0;
    background-color: #1f2d40;
    width: calc(100% + 40px);
  }

  label {
    margin-bottom: 10px;
  }
  input {
    border-radius: 10px;
    color: #fff;
    border: 2px solid #2c3e50;
    background-color: #1f2d40;
    text-align: center;
    padding: 10px;
    resize: none;
    height: 30px;
    width: calc(100% - 24px);
    font-size: 20px;
  }
</style>
