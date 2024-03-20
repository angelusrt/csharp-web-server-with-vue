<template>
  <div v-if="show" :class="[type, 'alert']">
    <button @click="dismiss">&times;</button>
    <p>{{ message }}</p>
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
    position: fixed;
    top: 20px;
    right: 20px;
    padding: 10px 20px;
    border-radius: 5px;
    color: #fff;
  }

  .info {
    background-color: #3498db;
  }

  .success {
    background-color: #2ecc71;
  }

  .warning {
    background-color: #f39c12;
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
    font: inherit;
    outline: inherit;
    position: absolute;
    top: 5px;
    right: 10px;
  }
</style>
