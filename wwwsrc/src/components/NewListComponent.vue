<template>
  <div class="newlist-component container-fluid">
    <form @submit.prevent="createList">
      <div class="form-group">
        <label for="itemTitle">List title</label>
        <input type="text"
               class="form-control"
               id="listTitle"
               aria-describedby="listTitle"
               placeholder="What's your list called?"
               v-model="state.newList.title"
        >
      </div>
      <div class="form-group">
        <label for="image">Published?</label>
        <input class="ml-3" type="checkbox" v-model="state.newList.isPublished">
      </div>
      <button type="submit" class="btn btn-primary mb-3">
        Add List
      </button>
    </form>
  </div>
</template>

<script>
import { listsService } from '../services/ListsService'
import { reactive } from 'vue'

export default {
  name: 'NewlistComponent',
  setup() {
    const state = reactive({
      newList: {

      }
    })
    return {
      state,
      createList() {
        listsService.createList(state.newList)
        state.newList = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
