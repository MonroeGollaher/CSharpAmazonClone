<template>
  <div class="listitem-component container-fluid">
    <div class="col-12">
      <h5>{{ listItems.price }}</h5>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ListitemComponent',
  props: ['listItemProp'],
  setup(props) {
    return {
      listItems: computed(() => props.listItemProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
