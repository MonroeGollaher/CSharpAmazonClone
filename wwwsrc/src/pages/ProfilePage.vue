<template>
  <div class="about text-center container-fluid">
    <h1>Welcome, {{ profile.name }}!</h1>
    <img class="rounded-circle" :src="profile.picture" alt="" />
    <p>{{ profile.email }}</p>
    <div class="row pb-3">
      <new-item-component />
    </div>
    <div class="row pb-3">
      <list-component v-for="list in lists" :key="list.id" :list-prop="list" />
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
  max-width: 100px;
}
</style>
