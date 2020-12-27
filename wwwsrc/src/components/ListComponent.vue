<template>
  <div class="list-component container-fluid">
    <div class="row card shadow">
      <h1>{{ list.title }}</h1>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'ListComponent',
  props: ['listProp'],
  setup(props) {
    return {
      list: computed(() => props.listProp),
      profile: computed(() => AppState.profile)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
