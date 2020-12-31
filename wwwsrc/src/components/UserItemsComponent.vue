<template>
  <div class="useritems-component container-fluid">
    <div class="row">
      <div class="col-6 d-flex flex-column border-rounded bg-light shadow radius15 my-3 p-4">
        <h5>{{ userItem.title }}</h5>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'UseritemsComponent',
  props: ['userItemProp'],
  setup(props) {
    return {
      userItem: computed(() => props.userItemProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.radius15 {
  border-radius: 15px;
}
img {
  height: 100px;
  width: 150px;
  object-fit: cover;
}
</style>
