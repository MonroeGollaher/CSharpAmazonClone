<template>
  <div class="about text-center container-fluid">
    <h1>Welcome, {{ profile.name }}!</h1>
    <img class="rounded-circle" :src="profile.picture" alt="" />
    <p>{{ profile.email }}</p>
    <div class="row pb-3">
      <new-item-component />
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
export default {
  name: 'Profile',
  setup() {
    return {
      profile: computed(() => AppState.profile),
      getLists() {
        listsService.getLists()
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
