<template>
  <div class="about container-fluid">
    <div class="row justify-content-center mt-3 text-center">
      <div class="col-3 py-2 card shadow radius15">
        <div class="row justify-content-center">
          <div class="col-12">
            <img class="rounded-circle" :src="profile.picture" alt="" />
          </div>
          <div class="col-12">
            <h5 class="pt-2">
              Welcome, {{ profile.name }}!
            </h5>
          </div>
          <div class="col-6 py-3">
            <new-list-component />
          </div>
          <div class="col-6 py-3">
            <new-item-component />
          </div>
        </div>
      </div>
    </div>

    <div class="row justify-content-center py-5">
      <div class="col-4">
        <h3>My Lists:</h3>
        <list-component v-for="list in lists" :key="list.id" :list-prop="list" />
      </div>
      <div class="col-2">
      </div>
      <div class="col-4">
        <h3>My Products:</h3>
        <div class="row">
          <div class="col-6">
            <user-items-component v-for="u in userItems" :key="u.id" :user-item-prop="u" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
import NewListComponent from '../components/NewListComponent'
import UserItemsComponent from '../components/UserItemsComponent'
import { itemsService } from '../services/ItemsService'
export default {
  name: 'Profile',
  components: { NewListComponent, UserItemsComponent },
  setup() {
    onMounted(async() => {
      await listsService.getLists()
      await itemsService.getUserItems()
    })
    return {
      profile: computed(() => AppState.profile),
      lists: computed(() => AppState.lists),
      userItems: computed(() => AppState.myItems)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 50px;
}
button:hover {
  outline: 1px solid#2f2f2f;
}
.radius15 {
  border-radius: 15px;
}
h3 {
  text-decoration: underline;
}
</style>
