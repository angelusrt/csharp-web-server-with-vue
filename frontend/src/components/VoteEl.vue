<template>
  <div class="vote-el">
    <h4>{{votes}} votos</h4>
    <img :src="name + '.gif'" :alt="name"/>
    <button @click="post">eu gosto</button>
  </div>
</template>

<script lang="ts">
  import Vue from 'vue'
  import api, {Data} from '../api'

  export default Vue.extend({
    name: "VoteEl",
    props: {votes: {type: Number}, name: {type: String}, pseudonym: {type: String}, postVote: {type: Function}},
    methods: {
      async post() {
        const data: Data = {pokemon: 0, pseudonym: ''}

        if (this.name === "squirtle") { data.pokemon = 1 }
        else if (this.name === "charmander") { data.pokemon = 2 }
        else { data.pokemon = 3 }

        data.pseudonym = this.pseudonym

        console.log(data)
        await this.postVote(data)
      }
    }
  })
</script>

<style>
  .vote-el {
    flex: 1;
    display: flex;
    flex-direction: column;
    text-align: center;
    padding: 40px;
    margin: 20px;
    background-color: transparent;
    border: 2px solid #2c3e50;
    border-radius: 10px;
  }

  h4 {
    font-weight: normal;
    margin-bottom: 20px;
  }
  img {
    width: 150px;
    margin: auto;
    image-rendering: optimizeSpeed;
    image-rendering: -moz-crisp-edges;
    image-rendering: -o-crisp-edges;
    image-rendering: -webkit-optimize-contrast;
    image-rendering: pixelated;
    image-rendering: optimize-contrast;
    -ms-interpolation-mode: nearest-neighbor;
  }

  button {
    font-weight: bold;
    color: #2c3e50;
    border: solid 2px #42b983;
    background-color: #42b983;
    padding: 10px 20px;
    border-radius: 10px;
    margin: 0 5px;
    font-style: normal;
    text-decoration: none;
  }
</style>
