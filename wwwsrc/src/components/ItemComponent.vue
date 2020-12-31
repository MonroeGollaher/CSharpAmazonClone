<template>
  <div class="items-component col-2 shadow card rounded container-fluid mt-5">
    <router-link :to="{name: 'ActiveItem', params: {id: item.id}}" @click="setActiveItem(item.id)">
      <div class="items itemImage" :style="'background-image: url('+item.image+')'">
        <div class="mt-4 to-hover">
          <h3>{{ item.title }}</h3>
          <h4>${{ item.price }}</h4>
        </div>
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

.items:hover{
  opacity: 0.75;
  transition: all 1s ease;
}
.items .to-hover{
  display: none;
  text-align: center;
}
.items:hover .to-hover{
  visibility: visible;
}
.itemImage {
  height: 300px;
  background-size: cover;
  background-position: center;
}
</style>
