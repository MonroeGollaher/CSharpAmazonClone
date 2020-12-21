<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
  </div>
  <div class="row">
    <item-component v-for="item in items" :key="item" :item-prop="item" />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { itemService } from '../services/ItemService'
import { AppState } from '../AppState'
import ItemComponent from '../components/ItemComponent'
export default {
  name: 'Home',
  components: { ItemComponent },
  setup() {
    onMounted(async() => {
      await itemService.getItems()
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
