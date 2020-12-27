<template>
  <div class="items-component col-3 shadow card rounded container-fluid mt-5">
    <router-link :to="{name: 'ActiveItem', params: {id: item.id}}" class="text-dark no-decoration" @click="setActiveItem(item.id)">
      <div class="row justify-content-center">
        <img :src="item.image" class="img-fluid justify-content-center" />
      </div>
      <div class="mt-4">
        <h3>{{ item.title }}</h3>
        <h4>${{ item.price }}</h4>
      </div>
    </router-link>
  </div>
</template>

<script>
import { computed } from 'vue'
import { itemsService } from '../services/ItemsService'
import { AppState } from '../AppState'

export default {
  name: 'ItemsComponent',
  props: ['itemProp'],
  setup(props) {
    return {
      item: computed(() => props.itemProp),
      profile: computed(() => AppState.profile),
      setActiveItem(itemId) {
        itemsService.setActiveItem(itemId)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img{
  max-width: 300px;
  max-height: 300px;
  // object-fit: cover;
}
</style>
