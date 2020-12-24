<template>
  <div class="activeitem-component container-fluid">
    <div class="" v-if="activeItem">
      <img :src="activeItem.image" class="img-fluid justify-content-center" />
      <h3>{{ activeItem.title }}</h3>
      <h4>${{ activeItem.price }}</h4>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { itemsService } from '../services/ItemsService'
import { useRoute } from 'vue-router'
export default {
  name: 'ActiveitemComponent',
  props: ['activeItemProp'],
  setup() {
    const route = useRoute()
    onMounted(async() => {
      await itemsService.setActiveItem(route.params.id)
    })
    return {
      activeItem: computed(() => AppState.activeItem)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
