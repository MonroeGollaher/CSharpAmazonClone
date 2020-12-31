<template>
  <div class="activelist container-fluid">
    <h1>Welcome to your {{ activeList.title }} wishlist</h1>
    <div class="row">
      <list-item-component v-for="li in items" :key="li.id" :list-item-prop="li" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { listItemsService } from '../services/ListItemService'
import { useRoute } from 'vue-router'
import ListItemComponent from '../components/ListItemComponent'
export default {
  name: 'Activelist',
  components: { ListItemComponent },
  setup() {
    const route = useRoute()
    onMounted(() => {
      listItemsService.getActiveListItems(route.params.id)
    })
    return {
      activeList: computed(() => AppState.activeList),
      items: computed(() => AppState.activeListItems)
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
