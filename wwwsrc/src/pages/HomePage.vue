<template>
  <div class="home container-fluid">
    <div class="row">
      <items-component v-for="item in items" :key="item" :item-prop="item" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { itemsService } from '../services/ItemsService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    onMounted(async() => {
      await itemsService.getItems()
    })
    return {
      items: computed(() => AppState.items),
      profile: computed(() => AppState.profile)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
