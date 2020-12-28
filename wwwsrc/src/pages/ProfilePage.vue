<template>
  <div class="about container-fluid">
    <div class="row justify-content-center mt-3">
      <div class="col-4 py-2 card shadow">
        <h5><img class="rounded-circle mr-3" :src="profile.picture" alt="" />Welcome, {{ profile.name }}!</h5>
      </div>
    </div>
    <!-- <p>Email: {{ profile.email }}</p> -->
    <div class="row pb-3">
      <div class="col-4">
        <h3>My Lists:</h3>
        <list-component v-for="list in lists" :key="list.id" :list-prop="list" />
      </div>
    </div>
    <div class="row pb-3">
      <new-item-component />
    </div>
  </div>
  <div class="row pb-3">
    <new-list-component />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
import NewListComponent from '../components/NewListComponent'
export default {
  name: 'Profile',
  components: { NewListComponent },
  setup() {
    onMounted(async() => {
      await listsService.getLists()
    })
    return {
      profile: computed(() => AppState.profile),
      lists: computed(() => AppState.lists)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 50px;
}
</style>
