<template>
  <div v-if="show" :class="[type, 'alert']">
    <p>{{ message }}</p>
    <button @click="dismiss">&times;</button>
  </div>
</template>

<script>
export default {
  props: {
    show: {type: Boolean},
    type: { type: String },
    message: { type: String },
    duration: { type: Number, default: 5000 },
    dismiss: Function
  },
  mounted() {
    if (this.duration > 0) {
      setTimeout(() => {
        this.dismiss()
      }, this.duration)
    }
  }
}
</script>

<style scoped>
  .alert {
    display: flex;
    justify-content: space-between;
    position: fixed;
    text-align: center;
    top: 20px;
    right: 20px;
    left: 20px;
    max-width: 200px;
    margin: 0 auto;
    padding: 10px 20px;
    border-radius: 10px;
    color: #fff;
  }

  .success {
    background-color: #42b983;
  }

  .error {
    background-color: #e74c3c;
  }

  button {
    background: none;
    border: none;
    color: inherit;
    cursor: pointer;
    padding: 0;
    padding-left: 10px;
    font: inherit;
    outline: inherit;
    top: 5px;
    right: 10px;
  }
</style>
