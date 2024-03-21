<template>
  <div id="app">
    <nav>
      <div class="nav-left">
        <h2>Pokemon Favorito</h2>
      </div>
      <div class="nav-right">
        <router-link to="/">Home</router-link>
        <router-link to="/about">About</router-link>
      </div>
    </nav>
    <router-view />
  </div>
</template>

<style>
* {
  margin: 0;
}

html {
  background-color: #1f2d40;
  width: 80%;
  margin: auto;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #fff;
}

nav {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 30px 0;
  margin-bottom: 80px;
  /*border: 2px solid #2c3e50;*/
}


nav a {
  font-weight: normal;
  background-color: #2c3e50;
  color: #fff;
  padding: 10px 20px;
  border-radius: 10px;
  margin: 0 5px;
  font-style: normal;
  text-decoration: none;
}

nav a.router-link-exact-active {
  font-weight: bold;
  color: #2c3e50;
  background-color: #42b983;
}

h1 {
  font-weight: 900;
  font-size: 40px;
}
h3 {
  margin-bottom: 80px;
  font-weight: normal;
}
</style>
