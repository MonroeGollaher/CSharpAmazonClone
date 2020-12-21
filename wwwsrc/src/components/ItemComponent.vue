<template>
  <div class="items-component col-3 shadow card rounded container-fluid mt-5">
    <img :src="item.image" class="img-fluid justify-content-center" />
    <h3>{{ item.title }}</h3>
    <h4>${{ item.price }}</h4>
  </div>
</template>

<script>
import { computed } from 'vue'

export default {
  name: 'ItemsComponent',
  props: ['itemProp'],
  setup(props) {
    return {
      item: computed(() => props.itemProp)
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
