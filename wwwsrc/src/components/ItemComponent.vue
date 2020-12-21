<template>
  <div class="item-component">
    <div class="col-4">
      <h3>{{ item.title }}</h3>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'

export default {
  name: 'ItemComponent',
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

</style>
