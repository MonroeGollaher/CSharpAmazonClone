<template>
  <div class="activeitem container-fluid">
    <div class="">
      <img :src="activeItem.image" class="img-fluid justify-content-center" />
      <h3>{{ activeItem.title }}</h3>
      <h4>${{ activeItem.price }}</h4>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Activeitem',
  setup() {
    return {
      activeItem: computed(() => AppState.activeItem)

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
