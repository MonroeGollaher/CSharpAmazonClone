<template>
  <div class="items-component col-3 shadow card rounded container-fluid mt-5">
    <router-link :to="{name: 'ActiveItem', params: {id: item.id}}" class="text-dark no-decoration" @click="setActiveItem(item.id)">
      <div class="row justify-content-center">
        <div class="col-12 items">
          <img :src="item.image" class="img-fluid justify-content-center itemImg" />
          <div class="mt-4 to-hover">
            <h3>{{ item.title }}</h3>
            <h4>${{ item.price }}</h4>
          </div>
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
img{
  width: 300px;
  height: 300px;
  object-fit: cover;
}
.items img:hover{
  opacity: 0.5;
  transition: all 1s ease;
}

.items .to-hover{
  display: none;
  text-align: center;
}

.items img:hover .to-hover{
  visibility: visible;
}
</style>
