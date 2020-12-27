<template>
  <div class="about container-fluid">
    <div class="row justify-content-center mt-3">
      <div class="col-4 card shadow">
        <img class="rounded-circle mr-3" :src="profile.picture" alt="" />
        <h5>Welcome, {{ profile.name }}!</h5>
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
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
export default {
  name: 'Profile',
  setup() {
    onMounted(async() => {
      await listsService.getLists()
    })
    return {
      profile: computed(() => AppState.profile),
      lists: computed(() => AppState.lists)
    }
  },
  components: { }
}
</script>

<style scoped>
img {
  max-width: 50px;
}
</style>
