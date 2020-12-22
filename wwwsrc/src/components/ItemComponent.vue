<template>
  <div class="items-component col-3 shadow card rounded container-fluid mt-5">
    <img :src="item.image" class="img-fluid justify-content-center" />
    <div class="mt-4">
      <h3>{{ item.title }}</h3>
      <h4>${{ item.price }}</h4>
      <button @click="deleteItem(item.id)" class="btn bg-transparent text-danger">
        <i class="fas fa-times"></i>
      </button>
      <button class="btn bg-transparent text-primary">
        <i class="far fa-edit"></i>
      </button>
      <button class="btn bg-transparent text-success">
        <i class="fas fa-plus"></i>
      </button>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { itemsService } from '../services/ItemsService'

export default {
  name: 'ItemsComponent',
  props: ['itemProp'],
  setup(props) {
    return {
      item: computed(() => props.itemProp),
      deleteItem(id) {
        itemsService.deletItem(id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img{
  width: 275px;
  height: 275px;
  object-fit: cover;
}
</style>
