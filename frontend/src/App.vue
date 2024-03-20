<template>
  <div id="app">
    <nav>
      <router-link to="/">Home</router-link>
      <router-link to="/about">About</router-link>
    </nav>
    <router-view />
  </div>
</template>

<style>
* {
  background-color: #1f2d40;
  margin: 0;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #fff;
}

nav {
  padding: 30px 30px;
  background-color: #2c3e50;
  border-radius: 20px;
  margin: 10px auto 20px auto;
  max-width: 200px;
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
  border: solid 2px #1f2d40;
}

nav a.router-link-exact-active {
  font-weight: bold;
  color: #2c3e50;
  border-color: #42b983;
  background-color: #42b983;
}
</style>
